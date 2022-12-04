// See https://aka.ms/new-console-template for more information
using DataStructures.LinkedList.DoubleWay;
using System.Collections.Generic;
/*var rnd = new Random();
var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
var linkedlist = new OneWayLinkedListed<int>(initial);
linkedList.Where(x => x > 5).ToList().ForEach(x => Console.WriteLine(x + " "));
*/
var linkedlist = new DoubleWayLinkedList<int>(new int[] {1,2,3});
foreach (var item in linkedlist)
    Console.WriteLine(item);
Console.ReadKey(); 
