# -*- coding: utf-8 -*-
"""
Created on Sat Nov  2 00:26:31 2019

@author: 31450
"""

# Perform PCA on two data sets(the same and different sectors)
import quandl
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import pyodbc
# Step1: Find a data set
# import data from quandl
def getdata(company):
    quandl.ApiConfig.api_key = "XnPszoqfQMwXx68zuZpc"
    mydata = quandl.get ('EOD/'+company)
    df = pd.DataFrame(mydata)
    return df # df includes open, close, high, low price, etc.

# add name into MFM_Financial.FinData.Instrument
# insert CompanyName, StockTicker, Market, Sector
def add_name (company, ticker, market,sector):
    conn = pyodbc.connect('Driver={SQL Server};'
                        'Server=DESKTOP-KB7BOB2;'
                        'Database=MFM_Financial;'
                        'Trusted_Connection=yes;')
    cursor = conn.cursor()
    cursor.execute("insert into [MFM_Financial].[FinData].[Instrument] values ('" + company + "','"+ ticker + "','" + market +"','" + sector + "')")
    conn.commit()
add_name('Microsoft','MSFT','NASDAQ','Technology')
add_name('General Electric','GE','NYSE','Industrial Goods')
add_name('Caterpillar','CAT','NYSE','Industrial Goods')
add_name('3M','MMM','NYSE','Industrial Goods')
add_name('United Technologies','UTX','NYSE','Industrial Goods')
add_name('Coca-Cola','KO','NYSE','Consumer Goods')
add_name('Exxon Mobil','XOM','NYSE','Basic Materials')

# get ID from MFM_Financial.FinData.Instrument
# then use ID to define the InstID in Database HistPrices
def get_name_id (ticker):
    conn = pyodbc.connect ('Driver={SQL Server};'
                        'Server=DESKTOP-KB7BOB2;'
                        'Database=MFM_Financial;'
                        'Trusted_Connection = yes;')
    cursor = conn.cursor()
    cursor.execute("select ID from [MFM_Financial].[FinData].[Instrument] where StockTicker ='" + ticker + "'")
    return cursor.fetchone()

# set Database HistPrices for the 7 stocks, including InstID, Date, OpenPrice, etc.
def add_timeseries(ticker):
    tickerid = get_name_id(ticker)[0]
    conn = pyodbc.connect('Driver={SQL Server};'
                        'Server=DESKTOP-KB7BOB2;'
                        'Database=MFM_Financial;'
                        'Trusted_Connection = yes;')                                                                                                                                                                                                                    
    cursor = conn.cursor()
    df = getdata(ticker)
    df=df.reset_index()
    for i in range(len(df)):
        cursor.execute("insert into [MFM_Financial].[FinData].[HistPrices] values ('"+ str(tickerid) +"',CONVERT(DATETIME,'"+
                    str(df.iloc[i]['Date'])+"',102),'"+ str(df.iloc[i]['Open']) +"','" +str(df.iloc[i]['High']) +"','" +
                    str(df.iloc[i]['Low']) + "','" + str(df.iloc[i]['Close']) +"','" + str(int(df.iloc[i]['Volume'])) + "')")
        conn.commit()
add_timeseries("MSFT")
add_timeseries("GE")
add_timeseries("CAT")
add_timeseries("MMM")
add_timeseries("UTX")
add_timeseries("KO")
add_timeseries("XOM")

# Step 2: Build a covariance matrix
# get data from SQL to python
def get_returns(ticker):
    conn = pyodbc.connect ('Driver={SQL Server};'
                        'Server=DESKTOP-KB7BOB2;'
                        'Database=MFM_Financial;'
                        'Trusted_Connection = yes;')
    a = pd.read_sql("select ClosePrice from [MFM_Financial].[FinData].[HistPrices],[MFM_Financial].[FinData].[Instrument] \
                   where HistPrices.InstID = Instrument.ID and Instrument.StockTicker ='" + ticker + "'",con=conn)
    df = pd.DataFrame(a)
    returns = pd.DataFrame()
    df = df.reset_index()
    for i in df:
        returns[i] = np.log(df[i][1:].values/df[i][:-1].values)
    return returns# returns means the log returns of each stock

def FourCompanyReturns(SameSector = True):
    returns_list1 = get_returns("MSFT")['ClosePrice'].tolist()
    returns_list1 = np.transpose(returns_list1)
    returns_list2 = get_returns("GE")['ClosePrice'].tolist()
    returns_list2 = np.transpose(returns_list2)
    returns_list3 = get_returns("CAT")['ClosePrice'].tolist()
    returns_list3 = np.transpose(returns_list3)
    returns_list4 = get_returns("MMM")['ClosePrice'].tolist()
    returns_list4 = np.transpose(returns_list4)
    returns_list5 = get_returns("UTX")['ClosePrice'].tolist()
    returns_list5 = np.transpose(returns_list5)
    returns_list6 = get_returns("KO")['ClosePrice'].tolist()
    returns_list6 = np.transpose(returns_list6)
    returns_list7 = get_returns("XOM")['ClosePrice'].tolist()
    returns_list7 = np.transpose(returns_list7)
    # Calculate the returns from the same or different 4 sectors
    if SameSector:
        returns = np.row_stack((returns_list2,returns_list3,returns_list4,returns_list5))# stocks from the same sector
        returns = np.transpose(returns)
    else:
        returns = np.row_stack((returns_list1,returns_list2,returns_list6,returns_list7))# stocks from different sectors
        returns = np.transpose(returns)
    # Calculate the covariance
    cov = np.cov(returns, rowvar = False)
    # Step 3: Perform eigendecomposition
    # Calculate the eigenvalues and eigenvectors
    eigenvalues, eigenvectors = np.linalg.eig(cov)
    # Calculate the explanation proportion of each eigenvalues
    prop = np.zeros([4,1])
    for i in range(4):
        perc = eigenvalues[i] / np.sum(eigenvalues)
        prop[i] = perc
    return [returns,eigenvalues,eigenvectors,prop]
# returns of same sector companies
returns_same = FourCompanyReturns(SameSector = True)[0]
# eigenvalues and eigenvectors of same sector companies
eigenvalues_same = FourCompanyReturns(SameSector = True)[1]
eigenvectors_same = FourCompanyReturns(SameSector = True)[2]
# proportions of each eigenvalues
prop_same = FourCompanyReturns(SameSector = True)[3]
# returns of different sector companies
returns_diff = FourCompanyReturns(SameSector = False)[0]
# eigenvalues and eigenvectors of different sector companies
eigenvalues_diff = FourCompanyReturns(SameSector = False)[1]
eigenvectors_diff = FourCompanyReturns(SameSector = False)[2]
# proportions of each eigenvalues
prop_diff = FourCompanyReturns(SameSector = False)[3]


# index of eigenvalues
# from the same sector
index_eigenvalues_same = -np.sort(-eigenvalues_same)#decsend the eigenvalues
index1= np.array([0,1,2,3])# index of original data
index_same = np.zeros(1*4)# index of the eigenvalues which wanna to decsend
for i in range(4):
    for j in range(4):
        if index_eigenvalues_same[i]==eigenvalues_same[j]:
            index_same[i] = j# index_same means ranking the eigenvalues by decsending
            # then it can be used to reorder other values
eigenvectors_same2 = np.zeros(4*4).reshape(4,4)#eigenvectors after decsending
for i in range(4):
    for j in range(4):
        if index1[i] == index_same[j]:
            eigenvectors_same2[i,:] = eigenvectors_same[j,:]# eigenvectors are also in order with the eigenvalues
prop_same2 = np.zeros([4,1])#proportions after decsending
for i in range(4):
    for j in range(4):
        if index1[i] == index_same[j]:
            prop_same2[i,:] = prop_same[j,:]# proportions are also in order with the eigenvalues
# from different sectors        
index_eigenvalues_diff = -np.sort(-eigenvalues_diff)
index_diff = np.zeros(1*4)# index of the eigenvalues which wanna to decsend
for i in range(4):
    for j in range(4):
        if index_eigenvalues_diff[i]==eigenvalues_diff[j]:
            index_diff[i] = j# index means ranking the eigenvalues by decsending
            # then it can be used to reorder other values
eigenvectors_diff2 = np.zeros(4*4).reshape(4,4)#eigenvectors after decsending
for i in range(4):
    for j in range(4):
        if index1[i] == index_diff[j]:
            eigenvectors_diff2[i,:] = eigenvectors_diff[j,:]# eigenvectors are also in order with the eigenvalues
prop_diff2 = np.zeros([4,1])#proportions after decsending
for i in range(4):
    for j in range(4):
        if index1[i] == index_diff[j]:
            prop_diff2[i,:] = prop_diff[j,:]# proportions are also in order with the eigenvalues



#output eigenvalues,eiggenvectors and the biggest proportion
def output_same(SameSector = True):
    print('eigenvalues')
    print(index_eigenvalues_same)
    print('eigenvectors')
    print(eigenvectors_same2)
    print('the biggest proportions')
    print(prop_same2[0])
    #return [index_eigenvalues_same,eigenvectors_same2, prop_same2]
output_same(True)

def output_diff(DiffSector = True):
    print('eigenvalues')
    print(index_eigenvalues_diff)
    print('eigenvectors')
    print(eigenvectors_diff2)
    print('the biggest proportions')
    print(prop_diff2[0])
output_diff(True)



# Step 4: Reduce dimensionality
# dimensional reduction, drop an eigenvector
def reduce_dimen(SameSector = True):
    if SameSector:
        g = returns_same
    else:
        g = returns_diff
    size = len(g)
    c = np.cov(g,rowvar = False)
    eigenvalues, eigenvectors = np.linalg.eig(c)
    r_reduce = np.rot90(eigenvectors)
    r_reduce = r_reduce [:,0]
    norm_g_reduce = np.zeros (size * 4).reshape(size,4)
    for i in range(4):
        norm_g_reduce[:,i] = g[:,i] - np.mean(g[:,i])
    # get the 3 biggest eigenvalues
    approx_reduce = np.dot(norm_g_reduce, eigenvectors_same[np.arange(0,3)].T)
    return approx_reduce
reduce_dimen_same = reduce_dimen(SameSector=True)
reduce_dimen_diff = reduce_dimen(SameSector=False)

# Step 5: Reconstruct original data
def reconstruct(SameSector = True):
    if SameSector:
        approx_reduce = reduce_dimen(SameSector=True)
        g = returns_same
    else:
        approx_reduce = reduce_dimen(SameSector=False)
        g = returns_diff
    OG = np.dot(approx_reduce , eigenvectors_same[np.arange(0,3)])
    for i in range(4):
        OG[:,i] = OG[:,i] + np.mean(g[:,i])
    return OG
reconstruct_same = reconstruct(SameSector = True)
reconstruct_diff = reconstruct(SameSector = False)


# some figures
import matplotlib.pyplot as plt
#original data
fig1=plt.figure(3)
plt.subplot(311)
plt.plot(returns_same,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Original Data')
plt.show()
#dimensional reduction data
plt.subplot(312)
plt.plot(reduce_dimen_same,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Dimensional Reduction Data')
plt.show()
#reconstruct original data
plt.subplot(313)
plt.plot(reconstruct_same,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Reconstruct Original Data')
plt.show()

fig2=plt.figure(3)
#original data
plt.subplot(311)
plt.plot(returns_diff,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Original Data')
plt.show()
#dimensional reduction data
plt.subplot(312)
plt.plot(reduce_dimen_diff,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Dimensional Reduction Data')
plt.show()
#reconstruct original data
plt.subplot(313)
plt.plot(reconstruct_diff,'o')
plt.yticks([-0.11, 0, 0.11])
plt.title('Reconstruct Original Data')
plt.show()
