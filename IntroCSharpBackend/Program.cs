

////Creacion de objetos:

//// Sale sale = new Sale();

//// Sale sale = new();



//// var sale = new Sale();




//Sale sale = new Sale(25);

//var message = sale.GetInfo();

//var saleWithTax  = new SaleWithTax(25 , 1.16m);

//var message1 = saleWithTax.GetInfo();


//Console.WriteLine(message);
//Console.WriteLine(message1);

////Herencia

//class SaleWithTax : Sale
//{

//    public decimal Tax { get; set; }

//    public SaleWithTax(decimal total, decimal tax) : base(total)
//    {

//        this.Tax = tax;

//    }

//    //Sobrescritura

//    public override string GetInfo()
//    {

//        return "El total es: " + Total + " El impuesto es " + Tax;

//    }

//    //Sobrecarga

//    public string GetInfo(string message )
//    {

//        return message;

//    }

//    public string GetInfo(int a)
//    {

//        return a.ToString();

//    }




//}






//class Sale
//{
//    public decimal Total { get; set; }


//    public Sale(decimal total) 
//    {
//        this.Total = total;

//    }


//    public virtual string GetInfo()
//    {


//        return "El total es" + Total;

//    }


//}







//Interfaces





//var sale = new Sale();

//var beer = new Beer();

//Some(sale);
//Some(beer);



//void Some(ISave save)
//{

//    save.Save();

//}





//interface ISale
//{

//    decimal Total { get; set; }


//}

//interface ISave
//{
//    public void Save();
//}




//public class Sale : ISale, ISave
//{

//    public decimal Total { get; set; }

//    public void Save()
//    {
//        Console.WriteLine("Se guardo en la BD");
//    }


//}

//public class Beer : ISave
//{
//    public void Save()
//    {
//        Console.WriteLine("Se guardo en Servicio");
//    }


//}




//Generics


//using System.Security.Principal;

//var numbers = new MyList<int>(5);


//numbers.Add(1);
//numbers.Add(2);
//numbers.Add(3);
//numbers.Add(4);
//numbers.Add(5);
//numbers.Add(6);
//numbers.Add(7);
//numbers.Add(8);






//Console.WriteLine(numbers.GetContent());


//var names = new MyList<string>(5);


//names.Add("a");
//names.Add("b");
//names.Add("c");
//names.Add("d");
//names.Add("e");
//names.Add("f");


//Console.WriteLine(names.GetContent());




//var beers = new MyList<Beer>(3);


//beers.Add(

//    new Beer() { Name = "Erdinger", 

//                 Price = 5

//    });

//beers.Add(

//    new Beer()
//    {
//        Name = "Corona",

//        Price = 1

//    });

//beers.Add(

//    new Beer()
//    {
//        Name = "Delirium",

//        Price = 10

//    });

//beers.Add(

//    new Beer()
//    {
//        Name = "Paulaner",

//        Price = 5

//    });


//Console.WriteLine(beers.GetContent());


//// Crear una instancia de la clase Beer
//var beer = new Beer
//{
//    Name = "Heineken",
//    Price = 3.5m
//};

//// Llamar al método ToString para obtener una representación de cadena
//string beerInfo = beer.ToString();

//Console.WriteLine(beerInfo);

//// La variable beerInfo ahora contendrá la cadena " Nombre: Heineken  Price: 3.5"


//public class MyList<T>
//{
//    private List<T> _list;

//    private int _limit;


//    public MyList( int limit) 
//    {
//        _limit = limit;

//        _list = new List<T>();


//    }

//    public void Add(T element) 
//    {
//       if(_list.Count < _limit) 
//        {

//         _list.Add(element);

//        }



//    }


//    public string GetContent()
//    {
//        string content = "" ;

//        foreach(var element in _list) 
//        {

//            content += element + " , ";

//        }

//        return content ;
//    }




//}





//public class Beer : Object
//{

//    public string Name { get; set; }

//    public decimal Price { get; set; }

//    //El metodo ToString() proporciona una representación de cadena de la instancia de la clase.

//    public override string ToString()
//    {
//        return " Nombre: " +  Name + "  Price: " + Price;
//    }




//}


//Libreria para pasar un JSON a un string
using System.Text.Json;




//Serializacion y Deserializacion


//Creando al objeto "hector"



//var hector = new People
//{

//    Name = "Hector",
//    Age = 36

//};

////Serializar: convertir un objeto de c# a Json para que pueda ser almacenada o transmitida.
////Ahora vamos a serializarlo a JSON :



//string json = JsonSerializer.Serialize(hector);

//Console.WriteLine(json);

////Resultado:  {"Name":"Hector","Age":36}

//string myJson = @"{

//    ""Name"" : ""Juan"",
//     ""Age"" : 36

//}";

////Deserializando (a partir de Json(representacion de datos) para llevarlo a un objeto)

//People juan = JsonSerializer.Deserialize<People>(myJson);

//Console.WriteLine(juan.Name);
//Console.WriteLine(juan.Age);




////People.Get();


//public class People
//{


//    public string Name { get; set; }
//    public int Age { get; set; }

//    public static string Get() => "Hola";   // metodo estatico no necesita instanciar la clase 

//    //  public static string Get() { return "Hola";}  // es lo mismo que la linea anterior, otra forma de codificar.


//}







//Programacion Funcional

//Funcion Pura: 


//Console.WriteLine(Sub(3,1));



//int Sub(int a , int b)
//{

//    return a - b;

//}


//Funcion No pura:

//Console.WriteLine(GetTomorrow());



//DateTime GetTomorrow()
//{
//    return DateTime.Now.AddDays(1); 
//}



//Pasamos dicha funcion NO pura a pura de la siguiente manera:

// Crear una instancia de DateTime para representar la fecha actual
//DateTime today = DateTime.Now;

// Llamar al método GetTomorrow pasando la fecha actual como argumento
//DateTime tomorrow = GetTomorrow(today);

// Imprimir el resultado
//Console.WriteLine($"Hoy es: {today}");
//Console.WriteLine($"Mañana será: {tomorrow}");

//Console.WriteLine(GetTomorrow(today));

//Console.WriteLine(GetTomorrow(new DateTime(2023,12,15)));


//// Este ya es una funcion pura
//DateTime GetTomorrow(DateTime date)
//{
//    return date.AddDays(1);
//}





//var beer = new Beer
//{
//    Name = "guiness"
//};

//Console.WriteLine(ToUpper(beer).Name);

//Console.WriteLine(beer.Name);



//Beer ToUpper(Beer beer)
//{


//    var beer2 = new Beer()
//    {
//        Name = beer.Name.ToUpper(),
//    };



//    return beer2;


//    //beer.Name = beer.Name.ToUpper();
//    //return beer;

//}




//class Beer
//{


//    public string Name { get; set; }
//}




//Funcion de 1ra clase (Funcion que se guarda en una variable)



//var show = Show;

//// show("Hola");   se esta ejecutando la variable mas no la funcion 


//Some(show, "Hola como estas");


//void Show(string message) // esta funcion es como un Action pues recibe un string pero no devuelve nada solo ejecuta. 
//{

//    Console.WriteLine(message);
//}



////Some es una funcion de orden superior que tiene como parametro una funcion fn

//void Some(Action<string> fn, string message)
//{

//    Console.WriteLine("Hace algo al inicio");

//    fn(message);
//    Console.WriteLine("Hace algo al final");
//}






//var show = Show;

//// show("Hola");   se esta ejecutando la variable mas no la funcion 


//Some(show, "Hola como estas");


//string Show(string message) // esta funcion es como un Func pues recibe un string y devuelve un string tambien. 
//{

//    return message.ToUpper();
//}




////Some es una funcion de orden superior que tiene como parametro una funcion fn

//void Some(Func<string, string> fn, string message)
//{

//    Console.WriteLine("Hace algo al inicio");

//    Console.WriteLine(fn(message)); 
//    Console.WriteLine("Hace algo al final");
//}






//Expresiones Lambda

//Func<int, int, int> sub = (int a, int b) => a - b;

//Es lo mismo escribir :   Func<int, int, int> sub = (int a, int b) => a - b;

//int sub(int a , int b)
//{
//    return a - b;
//}


//Func<int, int> some = (a) => a * 2;

////Es lo mismo :    Func<int, int> some = a => a * 2;

//Func<int, int> some2 = a =>
//{
//    a = a + 1;
//    return a * 5;
//};

//Ejecutando estas funciones:


//Console.WriteLine(sub(8,5));
//Console.WriteLine(some(2));
//Console.WriteLine(some2(3)); 







//Some((a, b) => a + b, 5);

//void Some(Func<int,int,int> fn, int number)
//{

//    var result = fn(number, number);

//    Console.WriteLine(result);

//}





//linq


//1) origen de datos

var names = new List<string>()
{
    "Hector","Francisco","Ana","Hugo","Pedro"
};

//Ordenando alfabeticamente:

//La consulta LINQ completa se puede leer como: "Para cada elemento n en la lista names, ordénalos por n y selecciona n". El resultado de esta consulta se
//almacena en la variable namesResult.

//2) Consulta
//var namesResult = from n in names orderby n select n;   //por defecto esta en forma ascendete

//foreach(var name in namesResult)
//{
//    Console.WriteLine(name);
//}



// lo mismo en forma descendente:


//La consulta LINQ completa se puede leer como: "Para cada elemento n en la lista names, ordénalos por n descendentemente  y selecciona n". El resultado de esta consulta se
//almacena en la variable namesResult.


//2) Consulta
//var namesResult = from n in names orderby n descending  select n;   //en forma descendente


////3) Ejecucion:
//foreach (var name in namesResult)
//{
//    Console.WriteLine(name);
//}




//Uso del Where:



var namesResult = from n in names where n.Length > 3 && n.Length < 5 orderby n descending select n;   //en forma descendente

//Escribiendo lo anterior pero ahora en funciones:

var namesResult2 = names.Where(n => n.Length > 3 && n.Length < 5).OrderByDescending(n => n).Select(d => d);


//3) Ejecucion:
foreach (var name in namesResult2)
{
    Console.WriteLine(name);
}
