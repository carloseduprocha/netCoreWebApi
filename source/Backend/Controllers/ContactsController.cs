using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contatos.Services;
using Contatos.Models;
using Contatos.DTOs;

namespace Contatos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactServices _contactService;

        public ContactsController(IContactServices contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> GetAll()
        {
            try
            {
                var contacts = _contactService.GetAll();

                if (contacts == null)
                    return BadRequest("Nenhum registro encontrado");

                return Ok(contacts);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao buscar contatos" });
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetById(int id)
        {
            try
            {
                var contact = _contactService.GetById(id);
                if (contact == null || contact.Id == 0)
                    return BadRequest("Não foi possível localizar o contato.");

                return Ok(contact);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao buscar contato." });
            }

        }

        [HttpPost]
        public ActionResult<ContactDto> Create(ContactDto contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var resp = _contactService.Create(contact);
               
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar contato", error = ex.Message });
            }

        }

        [HttpPut("{id:int}")]
        public ActionResult<ContactDto> Update(int id, ContactDto contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var resp = _contactService.Update(id, contact);
                if (resp == null || resp.Id ==0)
                    return BadRequest("Falha ao atualizar contato.");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar contato", error = ex.Message });
            }

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var resp = _contactService.Delete(id);
            if (resp == null || resp.Id == 0)
                return BadRequest("Falha ao excluir contato.");

            return Ok("Contato excluído com sucesso.");
        }
    }
}
