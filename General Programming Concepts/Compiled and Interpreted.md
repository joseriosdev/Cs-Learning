# Definition
## Compiler
The compiler reads the programming code and turns into machine code (0-1). This means that builds the program first, in other words... does a full translation before executing.

Examples of pure compiled languages are C, C++, Erlang, Haskell, Rust, and Go.

## Interpreter
It's like a human who works as an interpreter, translate the langauge as you go, simplier and faster. In software the interpreter goes line by line, at first this translation process was slower, but now is been popular and more likely to work with, thanks to Just-In-Time compilation or JIT.

Examples of common interpreted languages are PHP, Ruby, Python, and JavaScript.

> Most programming languages uses both of then, in addition, CLI and shells may be classified as interpreter languages

## Comparison
|Compiler  | Interpreter|
|:--------:|:----------:|
|Needs to be build first before running | Can be executed at once |
|Translate all the program to machine code | Does the translation at run time |
|Once built runs faster | Runs slower |
|Due to additional "object code" takes up more memory | Takes less memory |
|Is safer because deploys the machine code | Lack of safety because deploys the source code |
|Rigid for specific hardware architecture | Flexible for any hardware that has the interpreter |

![image](https://www.guru99.com/images/1/053018_0616_CompilervsI1.png)

### Resources
* [Interpreted vs Compiled Programming Languages: What's the Difference?](https://www.freecodecamp.org/news/compiled-versus-interpreted-languages/)
* [What is an interpreter in programming? NOT A COMPILER!](https://www.youtube.com/watch?v=Zcopr8JZrpU&ab_channel=IAmDevGrant)
* [What is a compiler in programming?](https://www.youtube.com/watch?v=86wdJ1CJkmI&ab_channel=IAmDevGrant)
* [Compiler vs Interpreter – Difference between compiler and interpreter](https://codeforwin.org/fundamentals/compiler-vs-interpreter)
* [Compiling C# into NATIVE code, just like Go, Rust and C++](https://www.youtube.com/watch?v=sa3XsvSiMtk&ab_channel=NickChapsas)