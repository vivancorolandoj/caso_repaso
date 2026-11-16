using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_repaso
{
    internal class Program
    {

        static string[] codigos = { "OC-101", "OC-102", "OC-103", "OC-104", "OC-105", "OC-106" };
        static string[] proveedores = {"TechCorp", "LogiExpress", "InsumosGlobal", "TechCorp2", "AlfaSuministros", "ServiRedes"
};
        static double[,] datos = { { 150, 10 }, { 450, 2}, { 80, 50}, { 1200, 1 }, { 25, 100 }, { 600, 3 } };
        static double[] montos = new double[6];
        static double total = 0;
        static int cont = 0;

        static public bool Validaciones(double precio, double cantidad)
        {
         if(precio > 0 && cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error: El precio y la cantidad deben ser mayores a cero.");
                return false; 
            }
        }

        static public void Monto_Acum_conta()
        {
            for(int i = 0; i < codigos.Length; i++)
            {
                montos[i] = datos[i, 0] * datos[i, 1];
                total = total + montos[i];
                if (montos[i] > 1000)
                {
                    cont++;
                }
            }
        }

        static public void Orden_desc()
        {
            int n = codigos.Length;
            for(int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double temp_Mon = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = temp_Mon;

                        string tmp_Cod = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tmp_Cod;

                        string tmp_Prov = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = tmp_Prov;

                        double tmp_precio = datos[j, 0];
                        datos[j, 0] = datos[j + 1, 0];
                        datos[j + 1, 0] = tmp_precio; 

                        double tmp_cant = datos[j, 1];
                        datos[j, 1] = datos[j + 1, 1];
                        datos[j + 1, 1] = tmp_cant;
                    }
                }
            }
        }

        static public void buscar(string cod_buscar)
        {
            bool encontrado = false;
            if (string.IsNullOrEmpty(cod_buscar))
            {
                Console.WriteLine("Error: El código a buscar no puede estar vacío.");
                return;
            }
            
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i] == cod_buscar)
                {
                    Console.WriteLine("Codigo encontrado:" +    codigos[i]);
                    Console.WriteLine("Proveedor: " + proveedores[i]);
                    Console.WriteLine("Monto: $" + montos[i]);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Código no encontrado..!!");
            }
        }

        static public void imprimir()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("CONTROL DE ORDENES DE COMPRA");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine("Codigo: " + codigos[i] + "| Prov:" + proveedores[i]+ "| Monto: $" + montos[i]);
            }
        }
        static void Main(string[] args)
        {
            Monto_Acum_conta();
            Orden_desc();
            imprimir();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("METRICAS RESUMEN: ");
            Console.WriteLine("* Gran Total Acumulado: $" +total);
            Console.WriteLine("* Compras Criticas (> $1,000): " + cont + " ordenes");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("PRUEBA DE BUSQUEDA");
            buscar("OC-102");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
