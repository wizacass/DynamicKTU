import matplotlib.pyplot as plt
import glob
import os

logsdir = "Logs/"
graphsdir = "Python/graphs/"


def analyze(filepath):
    counts = []
    data1 = []
    data2 = []
    data3 = []

    datafile = open(filepath, "r")
    for line in datafile:
        data = line.split(';')
        counts.append(int(data[0]))
        d1 = int(data[1]) / 1000
        d2 = int(data[2]) / 1000
        d3 = int(data[3]) / 1000
        data1.append(round(d1, 1))
        data2.append(round(d2, 1))
        data3.append(round(d3, 1))

    datafile.close()

    datafilename = filepath.split('/').pop()
    plot(datafilename, 1, counts, data1, data2, data3)


def plot(datafile, figurecount, counts, data1, data2, data3):
    path = f"{graphsdir}{datafile} {figurecount}.png"
    plt.figure(figurecount)
    fig1, = plt.plot(counts, data1, label="Recursion")
    fig2, = plt.plot(counts, data2, label="Dynamic")
    fig3, = plt.plot(counts, data3, label="Parallel")
    plt.xlabel("Result to be calculated")
    plt.ylabel("Ticks / 1000")
    plt.legend(handles=[fig1, fig2, fig3])
    plt.grid(True)
    plt.axes([0, max(counts), 0, max(data1)])
    plt.savefig(path)


os.makedirs(graphsdir)
logfiles = glob.glob(f"{logsdir}/*.csv")
for file in logfiles:
    print("Analyzing " + file)
    analyze(file)
