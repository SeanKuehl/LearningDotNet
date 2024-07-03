using CharactersApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CharactersApp.Controllers
{
    public class CharacterController : Controller
    {
        
        public IActionResult ViewCharacters()
        {

			List<Character> characterList = new List<Character>();
			using (var db = new CharacterContext())
			{
				characterList = db.Characters.ToList();
				db.SaveChanges();
			}


			return View(characterList);
        }

        [HttpGet]
        public IActionResult CreateCharacters()
        {
            return View();

        }


        [HttpPost]
        public IActionResult CreateCharacters(Character newCharacter)
		{

			if (ModelState.IsValid)
			{
				using (var db = new CharacterContext())
				{
					db.Add(newCharacter);
					db.SaveChanges();
				}


				List<Character> characterList = new List<Character>();
				using (var db = new CharacterContext())
				{
					characterList = db.Characters.ToList();
					db.SaveChanges();
				}





				return View("ViewCharacters", characterList);   //redirect to view page to see new entry

			}

			else
			{
				//redisplay the create screen with the error messages for the model given
				return View(newCharacter);
			}


		}


		public IActionResult DetailCharacters(int Id)
		{
			Character detailCharacter = new Character();

			using (var db = new CharacterContext())
			{
				detailCharacter = db.Characters.Where(x => x.Id == Id).FirstOrDefault();
				
			}

			

			return View(detailCharacter);

		}




		[HttpGet]
		public IActionResult EditCharacters(int Id)
		{


			Character editCharacter = new Character();
			using (var db = new CharacterContext())
			{
				editCharacter = db.Characters.Where(x => x.Id == Id).FirstOrDefault();

			}


			return View(editCharacter);

		}


		[HttpPost]
		public IActionResult EditCharacters(int Id, string firstName, string description, string comment)
		{

			
			using (var db = new CharacterContext())
			{
				var editCharacter = db.Characters.Where(x => x.Id == Id).FirstOrDefault();
				editCharacter.firstName = firstName;
				editCharacter.description = description;
				editCharacter.comment = comment;
				db.SaveChanges();
			}


			List<Character> characterList = new List<Character>();
			using (var db = new CharacterContext())
			{
				characterList = db.Characters.ToList();
				db.SaveChanges();
			}



			return View("ViewCharacters", characterList); //redirect to view page with the changes

		}




		[HttpGet]
		public IActionResult DeleteCharacters(int Id)
		{

			

			
			using (var db = new CharacterContext())
			{
				var charToDelete = db.Characters.Where(x => x.Id == Id).FirstOrDefault();
				db.Remove(charToDelete);
				db.SaveChanges();
			}


			List<Character> characterList = new List<Character>();
			using (var db = new CharacterContext())
			{
				characterList = db.Characters.ToList();
				db.SaveChanges();
			}


			return View("ViewCharacters", characterList);     //redirect to view page

		}


	}
}
