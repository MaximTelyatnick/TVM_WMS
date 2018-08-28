using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.IO;
using Ninject;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;
using SpreadsheetGear;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;


namespace TVM_WMS.BLL.Services
{
    public class ReportsService: IReportsService
    {
        List<WareHousesDTO> cellList = new List<WareHousesDTO>(); 
        private IUnitOfWork Database { get; set; }
        private IRepository<StoreNames> StoreNames;

        public static string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private string GeneratedReportsDir = HomePath;

        private StoreNamesDTO storeNameDTO;
        
        public ReportsService(IUnitOfWork uow)
        {
            Database = uow;
            StoreNames = Database.GetRepository<StoreNames>();
        }

        public void PrintWareHouses(List<WareHousesDTO> wareHouseList,StoreNamesDTO storeName)
        {
            
            storeNameDTO = storeName;
            SpreadsheetGear.IWorkbook workbook = Factory.GetWorkbook();
            SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
            SpreadsheetGear.IRange cells = worksheet.Cells;
            Dictionary<string, byte> HeaderColumn = new Dictionary<string, byte>();

            cellList = wareHouseList;
            int line = storeNameDTO.LineCount ?? 0;
            int column = storeNameDTO.ColumnCount ?? 0;
            int cell = storeNameDTO.CellCount ?? 0;
            int k = 0;

            int startPosition = 1;
            int currentPosition = 3;
            byte startHeaderPosition = 1;

            # region Header 

                  var parentName = StoreNames.GetAll().Where(m => m.StoreNameId == storeNameDTO.ParentId).ToList();

                  cells[0, startHeaderPosition].Value = parentName[0].Name +" "+ storeNameDTO.Name;
                  cells[0, startHeaderPosition].Font.Bold = true;

                   HeaderColumn.Add("Column" + 0, startHeaderPosition);

                    for (int i = line ; i >= 1; i--)
                    {
                        cells[startPosition + 1,startHeaderPosition].Value = "Этаж " + i;
                        cells[startPosition + 1, startHeaderPosition].Font.Bold = true;
                        startPosition++;
                    }

                    startPosition = 1;
                    startHeaderPosition = 2;
                    for (int j = 1; j < column+1; j++)
                    {
                        HeaderColumn.Add("Column" + j, startHeaderPosition);
                        worksheet.Cells[startPosition, startHeaderPosition].ColumnWidth *= 1.25; 
                        
                        cells[startPosition, startHeaderPosition].Value = "Стелаж " + j;
                        cells[startPosition, startHeaderPosition].Font.Bold = true;
                        startHeaderPosition++;
                    }
            #endregion

            #region Detail
        
                   for (int j = 1; j < line + 1; j++)
                   {

                       for (int i = 1; i < column + 1 ; i++)
                       {
                           if (cellList[k].NumberCell != 0)
                           {
                               cells[vsS[HeaderColumn["Column" + i]] + currentPosition].Value = cellList[k].NumberCell;
                               if (cellList[k].ZoneColor != null)
                                   cells[vsS[HeaderColumn["Column" + i]] + currentPosition].Interior.Color = ColorTranslator.FromHtml(cellList[k].ZoneColor.ToString());
                           }
                           else 
                           {
                               cells[vsS[HeaderColumn["Column" + i]] + currentPosition].Interior.Color = Color.Silver;
                           }
                           k = k + 1;
                       }
                       currentPosition++;
                   }

            #endregion

           # region Footer

             cells["B" + (startPosition + 1) + ":" + vsS[startHeaderPosition - 1] + (currentPosition - 1)].Borders.LineStyle = LineStyle.Continous;

           #endregion

           try
            {
               string documentAddresName = GeneratedReportsDir +
                                            String.Format("Карта склада ({0} {1})", parentName[0].Name, storeNameDTO.Name) + ".xls";
                workbook.SaveAs(documentAddresName, FileFormat.Excel8);

                Process process = new Process();
                process.StartInfo.Arguments = "\"" + documentAddresName + "\"";
                process.StartInfo.FileName = "Excel.exe";
                process.Start();
            }
            catch (System.IO.IOException) { MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не найден Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
   
        private string[] vsS =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

                "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK",
                "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV",
                "AW", "AX", "AY", "AZ",

                "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM",
                "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",

                "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM",
                "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"
            };

       public void Dispose()
       {
           Database.Dispose();
       }
    }
}
