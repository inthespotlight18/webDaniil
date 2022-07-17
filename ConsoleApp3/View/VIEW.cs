using System.Collections.Generic;

namespace VIEW
{
    public class DataPresenter
    {
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
            
            <h3>Site Show</h3>
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Database</title>
            </head>
            <body>
            ";

            html += "<table id='result' class='display' ><thead><tr>";
            for (int i = 0; i < l.Count; i++)
            {
                html += string.Format("<th>{0}</th> ", l[i]);

                html += "</tr></thead>";
            }
            html += "</table> </body></html>";

            return html;

        }


    }
}
/******************************************************************************************\
*                                                                                          * 
\******************************************************************************************/