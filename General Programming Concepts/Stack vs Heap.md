# The memory of any application is stored in 3 main parts
## 1 Machine Code
Where your application is converted in binary instructions

## 2 Stack
Comes from the data structure, stack, which follows the FILO (First In Last Out).
![image](https://cdn.programiz.com/sites/tutorial2program/files/stack.png)

### Call Stack - Responsabilities
* Keep track of the method or function been executed
* Keeping track of the local variables
* _Stack Pointer_ -> is the memory address of the last element added in the stack

## 3 Heap
Allows you to save memory in any order, which makes it consume more power when adding or removing things. This one is useful for global data.

## Important to mention
* The reason why you cant access a local variable is because is stored in the stack, like:

```csharp
public string str = "hi";
for(int i = 0; i < 10; i++) {
    Console.WriteLine("number: "+i);
}
Console.WriteLine("last number: "+i); // will not work because i existed in the stack
Console.WriteLine(str); // will work because str exists in the heap
```

* Therefore, we got something called Garbage Collector usually goes through the heap and collects the trash, looks if has or not a reference

* Anonymus functions? -> those functions alter a bit the memory, because combines then. Uses the stack when the anonymus function is called inside a method and the heap when referencing the variables that needs to operate

* Similar to above, the async functions when providing a result will be stored in the heap, later the garbage collector will pick it up


### Resources
* [Stack vs Heap Memory - Simple Explanation](https://www.youtube.com/watch?v=5OJRqkYbK-4&ab_channel=AlexHyett)
* [How to understand your program’s memory](https://www.freecodecamp.org/news/understand-your-programs-memory-92431fa8c6b/)