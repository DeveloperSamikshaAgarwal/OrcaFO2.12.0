using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace TradeStationToHedgeFund
{
    public class CommonClass
    {
        public static DataTable ActiveadaptorList()
        {
            DataTable dtAdaptorList = new DataTable();
            string query = "select EntityCode,isThisActive,Portfolio from Static.PortfolioStatus";
            dtAdaptorList = DBContext.GetDataSetFromQuery(Program.connectionString,query).Tables[0];
            return dtAdaptorList;
        }
    }
}
