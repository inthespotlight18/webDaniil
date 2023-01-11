using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace View
{
    public class DataPresenter
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string ListToHTML(List<string> l)
        {
            string html = @"
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
            
            <h3>Interface Methods</h3>
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>DataTable</title>
            </head>
            <body>               
            ";
            //html += "<h3>" + l[0] + "</h3>";
            html += "<h3>" + "Assembly version - " + Gapp.Gap.AssemblyVersion() + "</h3>";
            html += "<h4>" + "Domain - " + l[0] + "</h3>";

            html += "<table id='result' class='display' style='text-align:left;' ><thead><tr>";
            for (int i = 1; i < l.Count; i++)
            {
                html += string.Format("<th>{0}</th> ", l[i]);

                html += "</tr></thead>";
            }
            html += "</table> </body></html>";

            return html;

        }

        public static string DictToHTML(IDictionary<Guid, User> dict)
        {
            string html = @"
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
            
            <h3>Dictionary</h3>
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>DataTable</title>
            </head>
            <body>               
            ";



            html += "<table id='result' class='display' style='text-align:left;' ><thead><tr>";
            foreach (KeyValuePair<Guid, User> x in dict)
            {
                // Console.WriteLine("Key = {0}, Value = {1}", x.Key, x.Value);
               // html += string.Format("<th>{1}</th> ", x.Value);
                html += "<th>" + x.Value.name + "</th> ";
                html += "<th>" + x.Value.status + "</th> ";

                html += "</tr></thead>";

            }

            html += "</table> </body></html>";

            return html;

        }


        public static string DTtoHTML(DataTable dt)
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


            html += "<table id='result' class='display' ><thead><tr>";
            foreach (DataColumn col in dt.Columns)
            {
                Console.WriteLine(col.ColumnName);
                html += string.Format("<th>{0}</th> ", col.ColumnName);
            }
            html += "</tr></thead>";
            html +=
            "<tbody><tr>";



            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                    html += string.Format("<td>{0}</td> ", row[col.ColumnName]);
                html += "</tr>";
            }
            html += "</tbody>";



            html += "<tfoot><tr>";
            foreach (DataColumn col in dt.Columns)
            {
                Console.WriteLine(col.ColumnName);
                html += string.Format("<th>{0}</th> ", col.ColumnName);
            }
            html += "</tr></tfoot>";




            html += "</table> </body></html>";

            return html;
        }


        public static string LoginFormsHTML()
        {
            string html = @"
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
            
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>DataTable</title>
            </head>
            <body>               
            ";

            string RegForm = @"<form action='somefile.cs' method='POST'>

                <h1> Registration </h1>

                <div class='group'>
                    <label for=''>Username</label>
                    <input type = 'text' name= 'login'
                    value= '' 

                    placeholder=''>
                </div>

                <div class='group'>
                    <button type = 'submit' name='do_signup'>Register</button>
                </div>

            </form>";

            html += RegForm;

            html += "</table> </body></html>";

            return html;

        }

        public static string CommonPageHTML() 
        {
            string html = @"
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
            
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>DataTable</title>
            </head>
            <body>               

                <h1>Blank Page</h1>
            ";

            

            html += "</table> </body></html>";

            return html;
        }


    /*******************************************************************************************************************\
     *                                                                                                                 *
    \*******************************************************************************************************************/
}
}
