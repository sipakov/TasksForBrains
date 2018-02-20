There is a library class that deals with the assembly of Sharp projects. For test purposes, suppose it looks like this:
public class Compiler
{
public byte [] BuildProject (string projectPath)
{
// Simulate a stormy activity.
Thread.Sleep (500);

// In reality, there will be bytes of the collected dll.
return Encoding.UTF8.GetBytes (FilePath);
}
}
The task: to write an asynchronous wrapper over the Compiler, which will use it to implement the background assembly of projects. This class must satisfy the following requirements:
- You must return control to the calling code, without waiting for the complete assembly of the project.
- After the project is compiled, the calling code should be able to get bytes with the result.
- At a time when one project is already being processed, our class may be asked to collect something else. At the same time, you can collect only one project at a time - new tasks must be performed when the compiler is freed.
- The implementation must be thread safe.

Additional remarks:
- The Compiler class is considered a library class, and it can not be modified.
- In addition to the class with a direct solution to the problem, you need to provide a test project that illustrates its work.
- It is highly recommended to use modern capabilities of the framework, rather than writing code under .NET 2.0 =)


Есть библиотечный класс, занимающийся сборкой шарповых проектов. В тестовых целях предположим, что он выглядит так: 
public class Compiler 
{ 
public byte[] BuildProject( string projectPath ) 
{ 
// Имитируем бурную деятельность. 
Thread.Sleep( 500 ); 

// В реальности здесь будут байты собранной dll-ки. 
return Encoding.UTF8.GetBytes( FilePath ); 
} 
} 
Задача: написать асинхронную обёртку над Compiler-ом, которая будет с его помощью реализовывать фоновую сборку проектов. Этот класс должен удовлетворять следующим требованиям: 
- Необходимо возвращать управление вызывающему коду, не дожидаясь полной сборки проекта. 
- После того как проект будет собран, вызывающий код должен иметь возможность получить байты с результатом. 
- В то время, когда один проект уже обрабатывается, наш класс могут попросить собрать ещё что-нибудь. При этом одновременно можно собирать не более одного проекта - новые задачи должны выполниться, когда компилятор освободится. 
- Реализация должна быть потокобезопасной. 

Дополнительные замечания: 
- Класс Compiler считается библиотечным, и модифицировать его нельзя. 
- Помимо класса с непосредственным решением задачи нужно предоставить тестовый проект, иллюстрирующий его работу. 
- Настоятельно рекомендуется использовать современные возможности фреймворка, а не писать код под .NET 2.0 =)
