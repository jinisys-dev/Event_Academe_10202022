using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;

//Imports CoreLab.MySql

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class DataReaderToDatasetConverter
	{
		
		//Public Overloads Function convertDataReaderToDataSet(ByVal reader As MySqlDataReader, ByVal tablename As String, ByVal dataSet As DataSet)
		//    Try
		
		//        Do
		//            Dim schemaTable As dataTable = reader.GetSchemaTable()
		//            Dim dataTable As dataTable = New dataTable(tablename)
		
		//            If Not (schemaTable Is Nothing) Then
		//                Dim i As Integer
		//                For i = 0 To schemaTable.Rows.Count - 1
		
		//                    Dim dataRow As DataRow = schemaTable.Rows(i)
		//                    Dim columnName As String = dataRow("ColumnName").ToString
		
		//                    Dim column As DataColumn = New DataColumn(columnName, dataRow("DataType").GetType)
		//                    dataTable.Columns.Add(column)
		//                Next
		
		//                dataSet.Tables.Add(schemaTable)
		//                Do While (reader.Read())
		
		//                    Dim dataRow As DataRow = schemaTable.NewRow()
		//                    Dim x As Integer
		//                    For x = 0 To reader.FieldCount - 1
		//                        dataRow(x) = reader.GetValue(x)
		//                    Next
		//                    schemaTable.Rows.Add(dataRow)
		//                Loop
		//            Else
		//                ' No records were returned
		//                Dim column As DataColumn = New DataColumn("RowsAffected")
		//                dataTable.Columns.Add(column)
		//                dataSet.Tables.Add(dataTable)
		//                Dim dataRow As DataRow = dataTable.NewRow()
		//                dataRow(0) = reader.RecordsAffected
		//                dataTable.Rows.Add(dataRow)
		//            End If
		
		//        Loop While (reader.NextResult())
		//        Return dataSet
		//    Catch ex As Exception
		//        MsgBox("bsc: err: " & ex.Message())
		//    End Try
		
		//End Function
		public void convertDataReaderToDataSet(MySqlDataReader reader, string tablename, DataSet dataSet)
		{
			DataTable table = new DataTable(tablename);
			int i;
			for (i = 0; i <= reader.FieldCount - 1; i++)
			{
				System.Data.DataColumn dataColumn = new System.Data.DataColumn(reader.GetName(i));
				dataColumn.AllowDBNull = true;
				table.Columns.Add(dataColumn);
				
			}
			
			while (reader.Read())
			{
				System.Data.DataRow dataRow = table.NewRow();
				for (i = 0; i <= reader.FieldCount - 1; i++)
				{
					dataRow[i] = reader.GetValue(i);
				}
				table.Rows.Add(dataRow);
			}
			reader.Close();
			dataSet.Tables.Add(table);
		}
	}
	
}
