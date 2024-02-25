# Лабораторная работа №14

## Вариант №10
### Коллекции
1. Город (`Stack`)
2. Образовательное учреждение (`Dictionary`)


## Постановка задачи
### Часть 1
1.	Сформировать обобщенную стандартную коллекцию, содержащую ссылки на другие стандартные обобщенные коллекции.
2.	Заполнить коллекции объектами иерархии классов (лабораторная работа №10).

Выполнить запросы функции (всего должно быть выполнено не менее 5 запросов):
1. На выборку данных.
2. Получение счетчика (количества объектов с заданным параметром).
3. Использование операций над множествами (пересечение, объединение, разность).
4. Агрегирование данных.
5. Группировка данных 

Запросы должны быть выполнены двумя способами:
1. С использованием LINQ запросов.
2. С использованием методов расширения.
Каждый запрос выполняется в отдельной функции.
Примеры запросов (лабораторная работа №10).

### Часть 2
1.  В коллекцию MyNewCollection (лаб. раб. 12) добавить 3 метода расширения, реализующие следующие запросы:
    1. На выборку данных по условию.
    2. Агрегирование данных (среднее, максимум/минимум, сумма и пр.).
    3. Сортировка коллекции (по убыванию/по возрастанию).
    4. Группировка данных (дополнительное задание).

Методы расширения реализуются в отдельном статическом классе и должны в качестве параметров передавать делегаты, с помощью которых задаются правила выполнения соответствующих запросов.

Например, получение счетчика выполняется следующим образом: 

```C#
public static int Count(this MyCollection<Person> collection, Func<Person, bool> predicate)
{
    int count = collection.Where(predicate).Count();          
    return count;
}
```