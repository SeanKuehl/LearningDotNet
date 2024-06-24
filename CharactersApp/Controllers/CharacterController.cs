using CharactersApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CharactersApp.Controllers
{
    public class CharacterController : Controller
    {
        public static List<Character> characterList = new List<Character>();
        public static int idBase = 1;
        public IActionResult ViewCharacters()
        {
            

            return View(characterList);
        }

        [HttpGet]
        public IActionResult CreateCharacters()
        {
            return View();

        }


        [HttpPost]
        public IActionResult CreateCharacters(string firstName, string description, string comment)
		{
            Character newCharacter = new Character();
            newCharacter.Id = idBase;
            newCharacter.firstName = firstName;
            newCharacter.description = description;
            newCharacter.comment = comment;

            characterList.Add(newCharacter);

            idBase += 1;

			return View("ViewCharacters", characterList);   //redirect to view page to see new entry

		}


		public IActionResult DetailCharacters(int Id)
		{
            
            
            Character detailCharacter = characterList.FirstOrDefault(x => x.Id == Id);

			return View(detailCharacter);

		}




		[HttpGet]
		public IActionResult EditCharacters(int Id)
		{
			

			Character editCharacter = characterList.FirstOrDefault(x => x.Id == Id);

			return View(editCharacter);

		}


		[HttpPost]
		public IActionResult EditCharacters(int Id, string firstName, string description, string comment)
		{


            

			for (int i = 0; i< characterList.Count; i++)
            {
                if (characterList[i].Id == Id)
                {
                    Console.WriteLine("Please tell me this gets here");
                    characterList[i].firstName = firstName;
                    characterList[i].description = description;
                    characterList[i].comment = comment;
                }
            }

			return View("ViewCharacters", characterList); //redirect to view page with the changes

		}




		[HttpGet]
		public IActionResult DeleteCharacters(int Id)
		{

			characterList.Remove(characterList.Where(x => x.Id == Id).First()); //remove the item from the list
			

			return View("ViewCharacters", characterList);     //redirect to view page

		}


	}
}
