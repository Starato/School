from ast import Lambda
import unittest
import stock

class testStock(unittest.TestCase):
    #test symbol
    #test chart type
    #test time series
    #test start date
    #test end date
    def test_fetchSymbol(self):
        self.assertEqual(stock.fetchSymbol("ibm"), "IBM")
        self.assertRaises(Exception, stock.fetchSymbol, "abcdedefghi")
        self.assertEqual(stock.fetchSymbol("IbM"), "IBM")

    def test_chartType(self):
        self.assertEqual(stock.chartType("1"), 1)
        self.assertEqual(stock.chartType("2"), 2)
        self.assertRaises(Exception, stock.chartType, "asdfjio3e")
        self.assertRaises(Exception, stock.chartType, " ")
        self.assertRaises(Exception, stock.chartType, "")
        self.assertRaises(Exception, stock.chartType, "1.,/`")
    
    def test_get_time_series(self):
        timeSeriesObject1 = {"series": "1",
                            "interval": 60,
                            "isIntra": True}

        timeSeriesObject2 = {"series": "3",
                            "interval": Lambda,
                            "isIntra": False}
        self.assertEqual(stock.get_time_series("1", "5"), timeSeriesObject1)
        self.assertEqual(stock.get_time_series("3", Lambda), timeSeriesObject2)
        self.assertRaises(Exception, stock.get_time_series, "823ruiefjow", "98efuwcdio")
        self.assertRaises(Exception, stock.get_time_series, "", "")
        self.assertRaises(Exception, stock.get_time_series, " ", " ")
        
    def test_getDates(self):
        self.assertEqual(stock.getDates("2022-03-03", "2022-04-04"), ["2022-03-03", "2022-04-04"])
        self.assertRaises(Exception, stock.getDates, "hgruaidfj", "feoidjwcsklm")
        self.assertRaises(Exception, stock.getDates, "", "")
        self.assertRaises(Exception, stock.getDates, " ", " ")
        self.assertRaises(Exception, stock.getDates, "2022-02-02", "2022-01-01")
        self.assertRaises(Exception, stock.getDates, "2022/1/20", "2022/2/3")
        self.assertRaises(Exception, stock.getDates, "9-23-19", "9-30-22")
        self.assertRaises(Exception, stock.getDates, "fjfe-fej3-df3ji", "3r8u9uo-38u9jf-3hf8du")
        self.assertRaises(Exception, stock.getDates, "2.3.21", "4.5.22")
        self.assertRaises(Exception, stock.getDates, "2022-02-02", "2022-02-02")
        self.assertRaises(Exception, stock.getDates, "202huij", "2022-02-02")

if __name__ == "__main__":
    unittest.main()