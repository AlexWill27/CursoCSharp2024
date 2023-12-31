// See https://aka.ms/new-console-template for more information

//Esta línea de código agrega un espacio de nombres (namespace) a tu programa, en este caso, System.Threading.Channels. Sin embargo, en este código,
//no se utiliza ningún tipo de este espacio de nombres.


using System.Threading.Channels;

//Se crea un arreglo de enteros llamado numbers1 e inicializa con los valores {1, 2, 3, 4, 5, 6}.

var numbers1 = new int[] { 1, 2, 3, 4, 5, 6 };

var numbers2 = new int[] { 6, 7, 8, 9, 10 };

//Se crea otro arreglo de cadenas llamado numberWords e inicializa con las palabras correspondientes a los números {1, 2, 3, 4, 5, 6}.

var numberWords = new string[] { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis"};

//Esta línea utiliza el método de extensión Union proporcionado por LINQ. Union crea una secuencia que contiene todos los elementos distintos de las dos
//secuencias de origen. En este caso, crea una secuencia que contiene los números distintos de numbers1 y numbers2 y la asigna a la variable numbersUnion.

var numbersUnion = numbers1.Union(numbers2);




//Se crea una lista llamada beers.

//El tipo de la lista es una tupla (string Name, int IdBrand). Esto significa que cada elemento de la lista es una tupla que contiene una cadena (Name) y un entero (IdBrand).
//La lista se inicializa con cuatro tuplas que representan diferentes cervezas y sus identificadores de marca.

var beers = new List<(string Name, int IdBrand)>
{

    ("Pikantus", 1),
    ("Dunkel", 1),
    ("London Porter" , 2),
    ("London Pride", 2)


};

//Definición de la Lista de Marcas (brand):
//Se crea otra lista llamada brand.
//El tipo de la lista es una tupla (int IdBrand, string Name). Esto significa que cada elemento de la lista es una tupla que contiene un entero (IdBrand) y una cadena (Name).
//La lista se inicializa con dos tuplas que representan diferentes marcas y sus identificadores de marca.

var brand = new List<(int IdBrand, string Name)>
{
    (1,"Erdinger"),
    (2,"Fuller's")


};

//En resumen, el código crea dos listas de tuplas (beers y brand), donde beers representa diferentes cervezas junto con sus identificadores de marca, y brand representa
//diferentes marcas junto con sus identificadores de marca. Ambas listas utilizan tuplas con nombres descriptivos para los campos, lo que hace que el código sea más legible
//y comprensible.



var beersDetail = beers.Join(brand, b => b.IdBrand, br => br.IdBrand, (beer, brand) =>
{

    return new
    {


        Name = beer.Name,
        BrandName = brand.Name
    };



});


beersDetail.ToList().ForEach(element =>
{


    Console.WriteLine($"{element.Name} {element.BrandName}");

});











//Aquí, se convierte la secuencia numbersUnion a una lista (ToList()) y luego se utiliza el método ForEach para iterar sobre cada elemento de la lista y
//ejecutar la acción proporcionada como argumento (en este caso, imprimir cada elemento en la consola usando Console.WriteLine). El operador => se utiliza para definir
//una expresión lambda que representa la acción a realizar para cada elemento.

numbersUnion.ToList().ForEach(e =>
{

    Console.WriteLine(e);

});

//Este código está escrito en C# y utiliza la función Zip de LINQ para combinar dos secuencias (numbers1 y numberWords) en una nueva secuencia de pares, y
//luego imprime esos pares en la consola. Aquí está una explicación detallada del código:

//Aquí, la función Zip de LINQ se utiliza para combinar los elementos de las dos secuencias (numbers1 y numberWords) en pares, utilizando una función proporcionada
//como argumento. La función toma dos parámetros, n y w, que representan un número y su correspondiente palabra, y devuelve una cadena que combina ambos.
//La variable numbersWithZip se convierte en una secuencia de estas cadenas combinadas.

var numbersWithZip = numbers1.Zip(numberWords, (n, w) =>
{

    return n + " " + w;
});

//Se convierte la secuencia numbersWithZip a una lista (ToList()) y luego se utiliza el método ForEach para iterar sobre cada elemento de la lista y ejecutar
//la acción proporcionada como argumento (en este caso, imprimir cada cadena en la consola usando Console.WriteLine). La expresión lambda e => Console.WriteLine(e) representa
//la acción a realizar para cada elemento.

numbersWithZip.ToList().ForEach(e =>
{

    Console.WriteLine(e);

});

//En resumen, al llamar a ToList() después de una operación LINQ, se está convirtiendo la secuencia resultante en una lista que proporciona más opciones y métodos
//para trabajar con los datos. Esto permite un manejo más conveniente y flexible de los resultados en el código subsiguiente.

//En resumen, este código crea dos secuencias de datos (números y palabras), las combina en pares usando Zip y luego imprime cada par combinado en la consola.




// -----------------------------------------------------



Console.WriteLine(numbers1.All(e=>e>5));
Console.WriteLine(numbers2.All(e => e > 5));



//--------------------------------------------------------------

//Este código en C# utiliza LINQ (Language Integrated Query) para realizar una selección y proyección en una lista de tuplas. Aquí está el desglose paso a paso:

//1) Definición de la lista de datos:

//Se crea una lista llamada beersBrand que contiene tuplas con información sobre marcas de cerveza y las cervezas asociadas a cada marca.

//Esta línea de código está creando una lista llamada beersBrand, donde cada elemento de la lista es una tupla que contiene dos elementos: una cadena llamada Name y
//una lista de cadenas llamada Beers. Vamos a desglosar la estructura:

//new List<(string Name, List<string> Beers)>: Aquí se está creando una nueva instancia de la clase List que contendrá elementos de tipo tupla. La tupla tiene dos elementos:
//una cadena llamada Name y una lista de cadenas llamada Beers.

//("Erdinger", new List<string>{ "Pikantus", "Dunkel"}): Este es uno de los elementos de la lista. Es una tupla que tiene una cadena "Erdinger" como primer elemento (Name) y
//una nueva lista de cadenas que contiene "Pikantus" y "Dunkel" como segundo elemento (Beers).

//("Delirium", new List<string>{"Tremes", "Red"}): Este es otro elemento de la lista. Similar al anterior, es una tupla con una cadena "Delirium" como Name y una lista de cadenas que contiene "Tremes" y "Red"
//como Beers.

//En resumen, beersBrand es una lista que contiene tuplas, y cada tupla representa una marca de cerveza (Name) y una lista de cervezas asociadas a esa marca (Beers).
//Este tipo de declaración de tupla es una característica de C# que permite crear estructuras de datos más complejas y expresivas.

var beersBrand = new List<(string Name, List<string> Beers)>{

    ("Erdinger", new List<string>{ "Pikantus", "Dunkel"}),

    ("Delirium", new List<string>{"Tremes", "Red"}),


};

//2) Uso de SelectMany:

//SelectMany se utiliza para realizar una proyección plana de las listas anidadas. En este caso, se seleccionan todas las cervezas (beersBrand.Beers) de
//cada marca de cerveza (beersBrand). Se crea una nueva secuencia de objetos anónimos que contiene tanto la marca de cerveza original como la cerveza individual.

//SelectMany - Proyección plana:
//SelectMany se utiliza para realizar una proyección plana en la lista beersBrand.
//beersBrand => beersBrand.Beers selecciona la lista de cervezas (Beers) de cada elemento en beersBrand.
//(beerBrand, beer) => new { beerBrand, beer } crea un objeto anónimo que contiene la marca de cerveza original (beerBrand) y la cerveza individual (beer).
//El resultado es una secuencia de objetos anidados que incluye tanto la información de la marca de cerveza como la información de cada cerveza asociada.



//Este fragmento de código utiliza la operación LINQ SelectMany para realizar una proyección y aplanamiento (flattening) de una secuencia de elementos.
//Desglosemos la expresión:

//beersBrand.SelectMany(beersBrand => beersBrand.Beers, ...): Aquí, se está utilizando el método SelectMany. Este método se usa para proyectar cada elemento de una secuencia
//a otra secuencia y luego aplanar esas secuencias anidadas en una sola secuencia.
//beersBrand => beersBrand.Beers: El primer parámetro de SelectMany es una expresión lambda que toma cada elemento de la secuencia beersBrand y devuelve la secuencia
//Beers dentro de ese elemento. En otras palabras, se está seleccionando la propiedad Beers de cada elemento en beersBrand. Esto significa que beersBrand se refiere a
//un elemento de la secuencia beersBrand, que es una tupla que tiene una propiedad Beers que es una lista de strings.
//(beerBrand, beer) => new { beerBrand, beer }: El segundo parámetro de SelectMany es otra expresión lambda que toma dos argumentos: beerBrand y beer. Estos representan,
//respectivamente, un elemento de la secuencia original (beersBrand) y un elemento de la secuencia resultante de la proyección (beersBrand.Beers). Se crea un nuevo objeto
//anónimo con dos propiedades: beerBrand y beer. Esto significa que cada elemento en la secuencia resultante de SelectMany será un objeto anónimo que contiene tanto el
//elemento original como uno de los elementos de la lista Beers.

//Entonces, al final, BeerDetail será una secuencia de estos objetos anónimos que tienen información tanto de la marca de cerveza original (beerBrand) como del nombre de
//una cerveza individual (beer).


var BeerDetail = beersBrand.SelectMany(beersBrand => beersBrand.Beers,

         (beerBrand, beer) => new { beerBrand, beer }
    //Select - Nueva proyección:
    //Select se utiliza nuevamente para realizar otra proyección en la secuencia resultante de SelectMany.
    //Esta línea de código pertenece a la operación LINQ Select, que se utiliza para proyectar (transformar) elementos de una secuencia en una nueva forma.
    //Ahora desglosemos la expresión:
    //.Select(beerBrand => { ... }): Aquí, estamos utilizando el método Select para proyectar cada elemento de la secuencia resultante de la operación 
    //SelectMany. El parámetro beerBrand representa cada elemento en esta secuencia.
    //return new { ... }: Dentro de la expresión lambda, estamos creando un nuevo objeto anónimo utilizando la sintaxis de inicialización de objetos anónimos en C#.
    //Este objeto tiene dos propiedades:
    //BrandName = beerBrand.beerBrand.Name: La propiedad BrandName se asigna al nombre de la marca de cerveza (beerBrand.beerBrand.Name). Aquí, beerBrand.beerBrand hace
    //referencia al objeto original de la marca de cerveza (el cual contenía Name y Beers).
    //BeerName = beerBrand.beer: La propiedad BeerName se asigna al nombre de la cerveza (beerBrand.beer). Aquí, beerBrand.beer hace referencia a la cerveza individual
    //obtenida durante la operación SelectMany.
    //beerBrand => { return new { ... } } crea un nuevo objeto anónimo con las propiedades BrandName (nombre de la marca de cerveza) y BeerName (nombre de la cerveza).


    //Aquí se está utilizando una expresión Select en LINQ para proyectar (select) una nueva estructura de datos. En este caso, se está creando una nueva instancia anónima
    //con dos propiedades: BrandName y BeerName. Veamos cómo se desglosa:

    //beerBrand =>: Esto define un parámetro de entrada para la expresión lambda. En este contexto, beerBrand representa un elemento de la secuencia generada por
    //el SelectMany anterior.

    //new { BrandName = beerBrand.beerBrand.Name, BeerName = beerBrand.beer }: Aquí se está creando una nueva instancia anónima. Las propiedades BrandName y BeerName
    //se inicializan con los valores extraídos de beerBrand.

    //BrandName = beerBrand.beerBrand.Name: Accede al miembro Name de la propiedad beerBrand de la tupla original. beerBrand.beerBrand representa la primera parte de
    //la tupla original.

    //BeerName = beerBrand.beer: Accede al miembro beer de la tupla anidada en la propiedad beerBrand. beerBrand.beer representa la segunda parte de la tupla original.

    //En resumen, esta línea de código está creando una nueva instancia anónima con las propiedades BrandName y BeerName, donde BrandName toma el valor de Name de la
    //tupla original y BeerName toma el valor de la segunda parte de la tupla original.


    //Esta línea de código utiliza beerBrand.beerBrand.Name porque en la estructura de datos original beersBrand es una lista de tuplas con dos elementos, el primero es un
    //string llamado Name y el segundo es una lista de string llamada Beers. Por lo tanto, cuando se usa SelectMany, cada elemento de la lista se descompone en beerBrand,
    //que es una tupla con dos partes: beerBrand.beerBrand y beerBrand.beer.

    //Entendido, profundicemos en esa parte específica:

    //beerBrand representa cada elemento de la secuencia resultante de SelectMany. 
    //En cada iteración, beerBrand tiene dos partes: beerBrand.beerBrand y beerBrand.beer.
    //beerBrand.beerBrand.Name accede al componente Name de la tupla beerBrand.

    //beerBrand.beerBrand representa una tupla de la lista original de beersBrand, que tiene dos partes: Name y Beers. Por lo tanto, beerBrand.beerBrand.Name obtiene
    //el nombre de la marca (BrandName).

    //beerBrand.beer accede al componente beer de la tupla beerBrand.

    //beerBrand.beer representa un elemento de la lista Beers asociada a la marca actual. Por lo tanto, beerBrand.beer obtiene el nombre de la cerveza (BeerName).

    //En resumen, esta parte del código está creando una nueva proyección de datos que consiste en pares BrandName y BeerName, donde BrandName es el nombre de la marca
    //(beerBrand.beerBrand.Name) y BeerName es el nombre de la cerveza (beerBrand.beer).




    //Esta línea de código está utilizando la operación Select para proyectar cada elemento de la secuencia resultante de la operación SelectMany. Vamos a desglosarla:

    //.Select(beerBrand => { ... }): La operación Select se utiliza para proyectar (transformar) cada elemento de la secuencia.

    //beerBrand => { ... }: Para cada elemento de la secuencia resultante de la operación SelectMany, se ejecuta la expresión dentro del bloque { ... }.

    //return new { ... }: Se crea una nueva instancia anónima con dos propiedades: BrandName y BeerName.

    //BrandName = beerBrand.beerBrand.Name: La propiedad BrandName se asigna con el valor de beerBrand.beerBrand.Name. Aquí, beerBrand.beerBrand es la marca (beerBrand)
    //obtenida de la operación SelectMany, y Name es la propiedad de la marca que contiene el nombre.

    //BeerName = beerBrand.beer: La propiedad BeerName se asigna con el valor de beerBrand.beer. Aquí, beerBrand.beer es la cerveza (beer) obtenida de la operación SelectMany.

    //En resumen, esta línea de código está creando una nueva secuencia de instancias anónimas, donde cada instancia tiene dos propiedades: BrandName que contiene
    //el nombre de la marca y BeerName que contiene el nombre de la cerveza asociada a esa marca.

    ).Select(beerBrand =>
    {

        return new
        {
            BrandName = beerBrand.beerBrand.Name,
            BeerName = beerBrand.beer
        };

    });

//Resultado:

//La variable BeerDetail ahora contiene una secuencia de objetos anónimos con información sobre la marca de cerveza y la cerveza asociada, como se definió en
//la segunda proyección. Este resultado se puede utilizar o imprimir según sea necesario.

//Entonces, esta línea de código está creando un nuevo objeto anónimo para cada elemento en la secuencia, donde cada objeto tiene dos propiedades: BrandName con el nombre de
//la marca de cerveza y BeerName con el nombre de la cerveza individual asociada a esa marca. Este resultado se puede utilizar o manipular según sea necesario.


//-------------------------------



//Este fragmento de código realiza la operación final después de haber realizado algunas transformaciones utilizando LINQ. Vamos a desglosar lo que está sucediendo aquí:


//BeerDetail.ToList(): BeerDetail es una colección que se ha generado a través de operaciones LINQ en el código anterior.
//.ToList() convierte esta colección en una lista. Las operaciones LINQ, a menudo, generan secuencias que se pueden convertir en listas para facilitar su manipulación.

//ForEach(element => Console.WriteLine($"{element.BrandName} {element.BeerName}")):

//ForEach es un método que ejecuta una acción para cada elemento de la lista.

//element => Console.WriteLine($"{element.BrandName} {element.BeerName}") es una expresión lambda que define la acción que se realizará para cada elemento de la lista.

//element es el parámetro que representa cada elemento de la lista en la que se está iterando.

//Console.WriteLine($"{element.BrandName} {element.BeerName}") imprime en la consola una cadena formateada que combina el nombre de la marca (BrandName) y
//el nombre de la cerveza (BeerName).


//En resumen, esta parte del código imprime en la consola cada elemento de la lista BeerDetail, que contiene información combinada sobre la marca y el nombre de
//la cerveza. La salida será algo como:

//Erdinger Pikantus
//Erdinger Dunkel
//Delirium Tremes
//Delirium Red


//Cada línea representa una marca de cerveza junto con el nombre de cada cerveza asociada.

BeerDetail.ToList().ForEach(element =>
{

    Console.WriteLine($"{element.BrandName} {element.BeerName}");


});


//-------------------------------------------------------------------



