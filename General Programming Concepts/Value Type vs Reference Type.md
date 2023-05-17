# Value Types vs Reference
![image](https://net-informations.com/faq/general/img/reference-type.png)

__Value Types__ just store the value itself like:
* bool
* byte
* char
* decimal
* double
* enum
* float
* int
* long
* sbyte
* short
* struct
* uint
* ulong
* ushort
![image](https://miro.medium.com/v2/resize:fit:774/1*pWj7JtouE8UbGnZM5ITKbQ.png)

__Reference Type__ has a pointer to a space in memory which refers to the object, like `string` is really an object
* string
* class
* delegates
* arrays

> ReferenceType => HeapMemory ... ValueType => StackMemory

```csharp
class user {
    public int age = 26;
}

class app {
    static void Main(string[] args) {
        var user1 = new User();
        var user2 = user1;
        user2.age = 20;
        // both will be changed because are a reference
    }
}
```

### Resources
* [Reference types (C# reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
* [C# | Interview Question | Value type vs Reference Type](https://www.youtube.com/watch?v=46XIDinJqUw&ab_channel=RohitSharma)