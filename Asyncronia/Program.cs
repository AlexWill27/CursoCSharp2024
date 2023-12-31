// See https://aka.ms/new-console-template for more information


//Programacion sincrona


//Barman oBarman = new Barman();

//oBarman.CalientaSnack();
//Thread.Sleep(1000);
//oBarman.HacerCoctel();






//public class Barman
//{

//    public void CalientaSnack()
//    {

//        Console.WriteLine("Mete el Snack al Horno");
//        Thread.Sleep(10000);
//        Console.WriteLine("Saca el snack del horno");
//    }


//    public void HacerCoctel()
//    {
//        Console.WriteLine("Comienza a hacer el coctel");
//        Thread.Sleep(5000);
//        Console.WriteLine("Termina de hacer el coctel");



//    }




//}


//Programacion asincrona




//Este código tiene como objetivo simular el trabajo de un barman que realiza dos tareas diferentes: calentar un snack y hacer un cóctel.

//1) Task.Run(async () => {...}):

//Task.Run se utiliza para ejecutar una tarea en un hilo separado.
//async () => {...} define una función anónima asíncrona que será ejecutada por Task.Run.

Task.Run(async () =>
    {
        //2) Barman oBarman = new Barman():
        //Se crea una instancia de la clase Barman, que representa al barman.
        Barman oBarman = new Barman();

        //3)Task<bool> Tbool = oBarman.CalientaSnack():
        //Se llama al método CalientaSnack del objeto oBarman.
        //CalientaSnack devuelve una tarea (Task<bool>) que representa la acción de calentar un snack.
        //En este caso, CalientaSnack tiene un retardo simulado usando Thread.Sleep para representar el tiempo que lleva calentar el snack.
        Task<bool> Tbool = oBarman.CalientaSnack();

        //4)oBarman.HacerCoctel():
        //Después de iniciar la tarea de calentar el snack, el barman comienza a hacer un cóctel llamando al método HacerCoctel.
        //Al igual que con CalientaSnack, HacerCoctel también tiene un retardo simulado con Thread.Sleep.
        oBarman.HacerCoctel();

        //5)bool boolResult = await Tbool:
        //Se espera a que la tarea Tbool (calentar el snack) se complete.
        //Mientras la tarea está en progreso, el hilo principal puede realizar otras tareas sin bloquearse.
        //await permite que el hilo espere de manera asíncrona hasta que la tarea Tbool se complete.
        //boolResult almacena el resultado de la tarea Tbool.
        bool boolResult = await Tbool;

        //6)GetAwaiter().GetResult():
        //Esta parte bloquea el hilo principal hasta que todas las tareas asíncronas dentro de Task.Run se completen.
        //Esto es necesario porque Main es un método síncrono, y queremos esperar a que todas las tareas asíncronas finalicen antes de salir del programa.

    }).GetAwaiter().GetResult();




//7) Clase Barman:
//public class Barman
//{
//    //CalientaSnack: Método asíncrono que simula calentar un snack. Devuelve una tarea (Task<bool>) que se completa después de un retardo.
//    public async Task<bool> CalientaSnack()
//    {

//        Console.WriteLine("Mete el Snack al Horno");
//        Thread.Sleep(10000);
//        Console.WriteLine("Saca el snack del horno");

//        return true;
//    }

//    //HacerCoctel: Método que simula hacer un cóctel con un retardo.
//    public void HacerCoctel()
//    {
//        Console.WriteLine("Comienza a hacer el coctel");
//        Thread.Sleep(5000);
//        Console.WriteLine("Termina de hacer el coctel");



//    }


//    //En resumen, este código utiliza tareas asíncronas para simular las acciones de un barman que realiza múltiples tareas simultáneamente.
//    //La espera de resultados se gestiona mediante await.

//}




//---------------------------------------------------------------------

//1) Task.Run(async () => {...}):
//Task.Run se utiliza para ejecutar una tarea en un hilo separado.
//async () => {...} define una función anónima asíncrona que será ejecutada por Task.Run.


Task.Run(async () =>
{
    //2) Barman oBarman = new Barman():
    //Se crea una instancia de la clase Barman, que representa al barman.

    Barman oBarman = new Barman();

    //3) Task<bool> Tbool = oBarman.CalientaSnack():
    //Se llama al método CalientaSnack del objeto oBarman.
    //CalientaSnack es un método asíncrono que simula calentar un snack.
    //Se utiliza await para hacer una solicitud HTTP asincrónica a "http://google.com" utilizando HttpClient
    //Mientras la solicitud está en curso, el hilo principal puede continuar ejecutando otras tareas.
    //Después de la solicitud, se imprime "Saca el snack del horno" y devuelve true.

   
    Task<bool> Tbool = oBarman.CalientaSnack();



    //4) oBarman.HacerCoctel():
    //Después de iniciar la tarea de calentar el snack, el barman comienza a hacer un cóctel llamando al método HacerCoctel.
    //HacerCoctel es un método síncrono que simula hacer un cóctel.
    oBarman.HacerCoctel();

    //5) bool boolResult = await Tbool:
    //Se espera a que la tarea Tbool (calentar el snack) se complete.
    //await permite que el hilo espere de manera asíncrona hasta que la tarea Tbool se complete.
    //boolResult almacena el resultado de la tarea Tbool.
    bool boolResult = await Tbool;



    //6) .GetAwaiter().GetResult():
    //Esta parte bloquea el hilo principal hasta que todas las tareas asíncronas dentro de Task.Run se completen.
    //Esto es necesario porque Main es un método síncrono, y queremos esperar a que todas las tareas asíncronas finalicen antes de salir del programa.

}).GetAwaiter().GetResult();

//En resumen, este código utiliza tareas asíncronas para simular las acciones de un barman que realiza múltiples tareas simultáneamente,
//incluida una operación de red asíncrona (HttpClient). La espera de resultados se gestiona mediante await.






//Este código es parte de una clase Barman que simula las acciones de un barman realizando dos operaciones: CalientaSnack y HacerCoctel. Aquí está una explicación detallada:

public class Barman
{
    //1) public async Task<bool> CalientaSnack():
    //Este método es asincrónico, ya que utiliza la palabra clave async y devuelve una tarea (Task<bool>).
    public async Task<bool> CalientaSnack()
    {

        //Console.WriteLine("Mete el Snack al Horno");: Imprime un mensaje indicando que el barman está colocando el snack en el horno.

        Console.WriteLine("Mete el Snack al Horno");

        //HttpClient client = new HttpClient();: Crea una instancia de HttpClient, que se utiliza para realizar solicitudes HTTP.

        HttpClient client = new HttpClient();

        //await client.GetAsync("http://google.com");: Hace una solicitud HTTP asincrónica a "http://google.com" utilizando HttpClient.
        //La ejecución se detiene aquí hasta que la solicitud se complete.

        await client.GetAsync("http://google.com");

        //Console.WriteLine("Saca el snack del horno");: Después de que la solicitud HTTP se completa (o durante la espera), imprime un mensaje indicando que
        //el barman está sacando el snack del horno.

        Console.WriteLine("Saca el snack del horno");

        //return true;: Finalmente, devuelve true.
        return true;
    }


    //2) public void HacerCoctel():
    //Este método no es asincrónico y simplemente simula el proceso de hacer un cóctel.

    public void HacerCoctel()

    {
        //Console.WriteLine("Comienza a hacer el coctel");: Imprime un mensaje indicando que el barman comienza a hacer el cóctel.


        Console.WriteLine("Comienza a hacer el coctel");


        //Console.WriteLine("Termina de hacer el coctel");: Imprime un mensaje indicando que el barman ha terminado de hacer el cóctel.

        Console.WriteLine("Termina de hacer el coctel");

        //En resumen, la clase Barman tiene dos métodos: uno asincrónico que simula el calentamiento de un snack y otro síncrono que simula hacer un cóctel.
        //El método asincrónico utiliza HttpClient para realizar una solicitud HTTP a "http://google.com", y durante esta operación asincrónica, el hilo puede realizar
        //otras tareas antes de que la solicitud se complete.

    }




}
