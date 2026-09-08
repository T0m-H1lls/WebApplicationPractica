// план - создать что-то
// 1. запрос команды
// 2. ввод аргументов
// 3. отправка данных на сервер
// 4. получение ответа и отображение

//http://localhost:5148/api/MathOperation/Calc

using System.Net.Http.Json;
using ClassLibraryWebAPI;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:1488/api/");

MathSendData sendData = new MathSendData
{
    X = 15,
    Y = 2,
    Operator = '*',
};

var answer = await client.PostAsJsonAsync("MathOperation/Calc",sendData);

if (answer.StatusCode == System.Net.HttpStatusCode.OK)
{
    var result = await answer.Content.ReadFromJsonAsync<MathResult>();
    Console.WriteLine(result.Result);
}
else
{
    Console.Write("Ошибка");
    Console.WriteLine(await answer.Content.ReadAsStringAsync());
}