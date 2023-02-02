namespace CrudDemo.Tests;

using System.Collections.Generic;
using CrudDemo.Controllers;
using CrudDemo.Models;
using CrudDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Practice.Controllers;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var exception = new ExceptionHandleController();
        int add = 10;
        int unitAdd = exception.Add(5, 5);
        Assert.Equal(add, unitAdd);
    }
}
