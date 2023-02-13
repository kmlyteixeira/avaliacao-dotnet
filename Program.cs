using System;

namespace MyApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string arq = "ArquivoLeitura.txt";
      int contador = contadorLinhas(arq);
      int[] arrayDesordenado = new int[contador];
      int[] arrayOrdenado = new int[contador];

      arrayDesordenado = converteParaInt(File.ReadAllLines(arq));
      arrayOrdenado = insertionSort(arrayDesordenado);

      SortedSet<int> collection = new SortedSet<int>(); //collection de ordenação natural
      foreach (int linha in arrayDesordenado)
        collection.Add(linha);

      List<string> resultado = new List<string>();
      resultado.Add("Array Ordenado com Insertion Sort: " + String.Join(" | ", arrayOrdenado));
      resultado.Add("Ordenação natural da Collection SortedSet: " + String.Join(" | ", collection));

      File.WriteAllLines("ArquivoSaida.txt", resultado);
      Console.Write(String.Join("\n\n", resultado));

    }
    private static int contadorLinhas(string path)
    {
      int contador = 0;

      try
      {
        var linhas = File.ReadAllLines(path);
        foreach (var linha in linhas)
          contador++;
      }
      catch
      {
        Console.WriteLine("Arquivo inexistente!");
      }
      return contador;
    }

    private static int[] converteParaInt(string[] array)
    {
      int[] arrayConvertido = new int[array.Length];
      for (int i = 0; i < array.Length; i++)
      {
        arrayConvertido[i] = Int32.Parse(array[i]); //Converte o array de String para Int
      }
      return arrayConvertido;
    }

    private static int[] insertionSort(int[] array)
    {
      for (int j = 0; j < array.Length; j++)
      {
        int chave = array[j];  //chave recebe o valor do array na posição j
        int i = j - 1; //i recebe o valor de j - 1, assim o while começa a verificar a posição anterior a chave, pulando a primeira posição do array
        while ((i > -1) && (array[i] > chave))
        {  //Enquanto o valor de i for maior que -1 e o valor da posição i for maior que a chave, o while continua
          array[i + 1] = array[i];
          i--;  //i recebe o valor de i - 1, assim o while continua verificando a posição anterior a chave
        }
        array[i + 1] = chave; //Quando o while termina, a chave recebe o valor da posição i + 1
        Console.WriteLine(("\n" + (j + 1) + "º passo -> " + String.Join(" | ", array)));
      }
      return array;
    }
  }
}