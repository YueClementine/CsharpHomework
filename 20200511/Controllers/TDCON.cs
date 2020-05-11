using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TDCON : ControllerBase
    {

        private readonly Context todoDb;
     
        public TDCON(Context context)
        {
            this.todoDb = context;
        }

   
        [HttpGet("{id}")]
        public ActionResult<Item> GetTodoItem(long id)
        {
            var todoItem = todoDb.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }
        [HttpGet]
        public ActionResult<List<Item>> GetTodoItems(string name, bool? isComplete)
        {
            var query = buildQuery(name, isComplete);
            return query.ToList();
        }
        [HttpGet("pageQuery")]
        public ActionResult<List<Item>> queryTodoItem(string name, bool? isComplete, int skip, int take)
        {
            var query = buildQuery(name, isComplete).Skip(skip).Take(take);
            return query.ToList();
        }

        private IQueryable<Item> buildQuery(string name, bool? isComplete)
        {
            IQueryable<Item> query = todoDb.TodoItems;
            if (name != null)
            {
                query = query.Where(t => t.Name.Contains(name));
            }
            if (isComplete != null)
            {
                query = query.Where(t => t.IsComplete == isComplete);
            }
            return query;
        }
        [HttpPost]
        public ActionResult<Item> PostTodoItem(Item todo)
        {
            try
            {
                todoDb.TodoItems.Add(todo);
                todoDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return todo;
        }
        [HttpPut("{id}")]
        public ActionResult<Item> PutTodoItem(long id, Item todo)
        {
            if (id != todo.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                todoDb.Entry(todo).State = EntityState.Modified;
                todoDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(long id)
        {
            try
            {
                var todo = todoDb.TodoItems.FirstOrDefault(t => t.Id == id);
                if (todo != null)
                {
                    todoDb.Remove(todo);
                    todoDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}