using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace WebSiteStackBuilders
{
    public class Reproduce
    {
       public void Inicializar()
        { }

        public string captureMessage(string value, DataTable dtTablaCanciones)
        {
            string msnReturn = "";
            int numCancion = 0;
            int indiceSonido = 0;
            List<DataRow> listRows;

            var v = from myRow in dtTablaCanciones.AsEnumerable()
                    where myRow.Field<string>("SOUNDVALUE") == value
                    select myRow;
            listRows = v.ToList();
            numCancion = (int)listRows[0][1];
            indiceSonido = (int)listRows[0][0];

            v = from myRow in dtTablaCanciones.AsEnumerable()
                where myRow.Field<int>("NUMSONG") == numCancion && myRow.Field<int>("SECUENCIAL") > indiceSonido
                select myRow;

            listRows = v.ToList();

            foreach (DataRow item in listRows)
            {
                msnReturn = msnReturn + item[3] + " ";
            }
            if (msnReturn.Length == 0)
                msnReturn = "No sounds reproduced";

            return msnReturn;
        }

        public void createRows(ref DataTable dtTablaCanciones, ref int contador, int numCancion)
        {
            DataRow dr;

            for (int i = 0; i < 4; i++)
            {
                dr = dtTablaCanciones.NewRow();
                dr[0] = contador + 1;
                dr[1] = numCancion;

                switch (i + 1)
                {
                    case 1:
                        switch (numCancion)
                        {
                            case 1:
                                dr[2] = "brr";
                                dr[3] = dr[2];
                                break;
                            case 2:
                                dr[2] = "pep";
                                dr[3] = dr[2];
                                break;
                            case 3:
                                dr[2] = "bribri";
                                dr[3] = "bri-bri";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (numCancion)
                        {
                            case 1:
                                dr[2] = "fiu";
                                dr[3] = dr[2];
                                break;
                            case 2:
                                dr[2] = "birip";
                                dr[3] = dr[2];
                                break;
                            case 3:
                                dr[2] = "plop";
                                dr[3] = dr[2];
                                break;
                        }
                        break;
                    case 3:
                        switch (numCancion)
                        {
                            case 1:
                                dr[2] = "criccric";
                                dr[3] = "cric-cric";
                                break;
                            case 2:
                                dr[2] = "trritrri";
                                dr[3] = "trri-trri";
                                break;
                            case 3:
                                dr[2] = "criccric";
                                dr[3] = "cric-cric";
                                break;
                        }
                        break;
                    case 4:
                        switch (numCancion)
                        {
                            case 1:
                                dr[2] = "brrah";
                                dr[3] = dr[2];
                                break;
                            case 2:
                                dr[2] = "croac";
                                dr[3] = dr[2];
                                break;
                            case 3:
                                dr[2] = "brrah";
                                dr[3] = dr[2];
                                break;
                        }
                        break;
                    default:
                        break;
                }



                dtTablaCanciones.Rows.Add(dr);
                contador++;
            }
        }
    }
}