using AccountingApp.Data.BlankData;
using System.Collections.Generic;

namespace AccountingApp.DataBase
{
    public static class DataBaseHandler
    {
        private static List<ProcessorData> processorData = new List<ProcessorData>();
        private static List<GraphicsData> graphicsData = new List<GraphicsData>();
        private static List<string> IpAdresses = new List<string>();
        private static List<string> keys = new List<string>();
        private static List<string> osNames = new List<string>();
        private static List<string> motherBoards = new List<string>();
        private static List<string> hddS = new List<string>();

        public static List<ProcessorData> ProcessorData { get => processorData; set => processorData = value; }
        public static List<GraphicsData> GraphicsData { get => graphicsData; set => graphicsData = value; }
    }
}