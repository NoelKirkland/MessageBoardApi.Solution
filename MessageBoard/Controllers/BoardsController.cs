using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoardsController : ControllerBase
  {
    private MessageBoardContext _db;

    public BoardsController(MessageBoardContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Board>> Get()
    {
      return _db.Boards.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Board> Get(int id)
    {
      return _db.Boards.FirstOrDefault(entry => entry.BoardId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var boardToDelete = _db.Boards.FirstOrDefault(entry => entry.BoardId == id);
      _db.Boards.Remove(boardToDelete);
      _db.SaveChanges();
    }
  }
}