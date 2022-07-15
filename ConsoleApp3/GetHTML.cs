using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class GetHTML
    {
        public static string GetHtmlOutput(DataSet ds)
        {
            string html =

            @"
            <!DOCTYPE html>
            <html lang='en'>
            <html><head>

 

            <script type='text/javascript' language='javascript' src='https://code.jquery.com/jquery-3.5.1.js'></script>

            <link rel='stylesheet' type='text/css' href='https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css'/>

            <script type='text/javascript' src='https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js'></script>

 

            <script type='text/javascript' class='init'>

                $(document).ready(function () 
                {
                    $('#result').DataTable();
                });

            </script>

            </head>

            

            <h3>Site Show</h3>

                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>


                <title>Database</title>

            </head>
            <body>

            ";




            
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                    DataTable dt = ds.Tables[i];
                    html += "<table id='result' class='display' ><thead><tr>";
                    foreach (DataColumn col in dt.Columns)
                    {
                        //Console.WriteLine(col.ColumnName + " COLUMN");
                        html += string.Format("<th>{0}</th> ", col.ColumnName);
                    }
                    html += "</tr></thead>";
                    html +=
                    "<tbody><tr>";


                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            //Console.WriteLine(row[col.ColumnName] + " ROW");
                            html += string.Format("<td>{0}</td> ", row[col.ColumnName]);
                        }

                        html += "</tr>";
                    }
                    html += "</tbody>";


                    html += "<tfoot><tr>";
                    foreach (DataColumn col in dt.Columns)
                    {
                        //Console.WriteLine(col.ColumnName);
                        html += string.Format("<th>{0}</th> ", col.ColumnName);
                    }
                    html += "</tr></tfoot>";

                
            }



            html += "</table> </body></html>";

            return html;





        }

    }
}
