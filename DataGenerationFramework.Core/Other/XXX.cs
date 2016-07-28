using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DataGenerationFramework.Core
{
    /// <summary>
    /// Purpose: Class for generating test data
    /// Author: Justin Bellars
    /// Note: Randomization data can either be pulled from a database (as seen below) or stored in arrays or lists (as also demonstrated below).
    /// </summary>
    class DataGenerator
    {
        //public static readonly PersonGeneratorEntities db = new PersonGeneratorEntities();
        public static Dictionary<string, int> States;

        #region Constructor
        public DataGenerator()
        {

            // These are the states and US Territories that CB uses to populate the state drop-downs in the OLA
            States = db.States.OrderBy(t => t.Id).ToDictionary(t => t.Abbreviation, t => t.Id);
            #region States Array
            //{
            //    {"AA",1},{"AE",2},{"AK",3},{"AL",4},{"AP",5},{"AR",6},{"AS",7},{"AZ",8},{"CA",9},{"CO",10},{"CT",11},{"DC",12},{"DE",13},{"FL",14},{"GA",15},{"GU",16},{"HI",17},{"IA",18},{"ID",19},{"IL",20},{"IN",21},{"KS",22},{"KY",23},{"LA",24},{"MA",25},{"MD",26},{"ME",27},{"MI",28},{"MN",29},{"MO",30},{"MP",31},{"MS",32},{"MT",33},{"NC",34},{"ND",35},{"NE",36},{"NH",37},{"NJ",38},{"NM",39},{"NV",40},{"NY",41},{"OH",42},{"OK",43},{"OR",44},{"PA",45},{"PR",46},{"RI",47},{"SC",48},{"SD",49},{"TN",50},{"TX",51},{"UT",52},{"VA",53},{"VI",54},{"VT",55},{"WA",56},{"WI",57},{"WV",58},{"WY",59}
            //};

            #endregion States Array
        }
        #endregion Constructor

        #region Properties

        private static readonly string[] titlesM = { "Mr.", "Dr.", "Mr." };

        private static readonly string[] titlesF = { "Ms.", "Mrs.", "Dr." };

        #endregion Properties

        #region User Details

        #region First Name

        #region Small Set of First Names

        public static string RandomizeFirstName()
        {
            string[] fNames =
            {
                "Abihud", "Adrian", "Aelfred", "Aeowynn", "Agatha", "Ainsley", "Alejandro", "Alessandra", "Alfonso", "Alfredo", "Aloysius", "Amelia", "Anakin", "Anastasia", "Anders", "Andreas", "Annelisse", "Armando", "Athanasius", "Attila", "Augustine",
                "Balthazar", "Bartholomew", "Beltashazzar", "Bob", "Boris", "Bradford", "Breanna", "Bronson", "Bronwynn", "Bruce", "Bruton",
                "Caleb", "Caligula", "Calvin", "Cameron", "Candace", "Captain", "Carissa", "Celeste", "Charisse", "Charity", "Chastity", "Chartreuse", "Chauncey", "Chaz", "Chelsea", "Chesterfield", "Cheswick", "Chocolate", "Clementine", "Colby", "Colonel", "Constantine", "Cooter",
                "Dakota", "David", "Demetrius", "Deon", "Desmond", "Django", "Dmitriy", "Dukes",
                "Eaton", "Ebenezer", "Ekaterina", "Eliza", "Elvira", "Elvis", "Enrique", "Esau", "Esmerelda", "Esteban", "Eusebius", "Evegeniya", "Ezekiel",
                "Fabien", "Fabio", "Faisal", "Fatima", "Felix", "Festivus", "Festus", "Floyd", "Fortunatus", "Franz-Josef",
                "Galileo", "Gamaliel", "Gamaliel", "Garett", "Gaspar", "Gaston", "Georgette", "Gertrude", "Ghee", "Gilgamesh", "Gisela", "Goldie", "Goose", "Greedo", "Greta", "Grimace", "Griselda", "Guadelupe", "Gustavo", "Günther",
                "Habakkuk", "Hadassah", "Hades", "Haggai", "Hananiah", "Hezekiah", "Hilkiah", "Hiram", "Horatio", "Hosanna",
                "Iago", "Ian", "Ichabod", "Ignatius", "Iliana", "Indiana", "Indira", "Inga", "Ingrid", "Isabeau", "Isabella", "Ishmael", "Isolde", "Ivanna",
                "Jack", "Jade", "Jael", "Jagdeesh", "Jamal", "Jamison", "Janelle", "Jarvis", "Jasmine", "Jasper", "Jaspreet", "Javier", "Jazz", "Jean-Luc", "Jean-Paul", "Jedediah", "Jefferson", "Jehoshaphat", "Jehu", "Jeremiah", "Jermaine", "Jesse", "Jezebel", "Jillian", "Joab", "Jocelyn", "Joelle", "Johann", "Joshua", "Joy", "Joyel", "Juan Pablo", "Julianna", "Juliette", "Julius", "June", "Jupiter", "Jürgen", "Justimus", "Justo", "Justus",
                "Kakashi", "Kalel", "Karthika", "Kassandra", "Katelyn", "Katja", "Katya", "Kayla", "Kelly", "Kendall", "Kennedy", "Keturah", "Kiera",
                "Lando", "Landon", "Laralee", "Lateesha", "Lavender", "Leia", "Leonidas", "Liliana", "Lincoln", "Ljubljana", "Lucinda", "Lucretia", "Ludmilla", "Ludwig", "Luke", "Lukasz",
                "Mabeline", "Maeve", "Maher-shalal-hash-baz", "Majed", "Manfred", "Mansour", "Marcel", "Margaret", "Matthias", "Maverick", "Mei-li", "Melikalikimaka", "Merriwether", "Methuselah", "Minerva", "Miriam", "Miroslav",
                "Naamah", "Nadab", "Nahaliel", "Nahath", "Nahum", "Natalie", "Natasha", "Nathaniel", "Naveen", "Nebuchadnezzar", "Nebuzaradan", "Nehemiah", "Nicodemas", "Nikolina", "Noah", "Noelle",
                "Obadiah", "Obed", "Onesimus", "Ophrah", "Orlando", "Ottavia", "Ovaltine",
                "Paddy", "Padme", "Paola", "Paolo", "Pascal", "Patsy", "Patty", "Patty", "Paulina", "Pavel", "Payson", "Penelope", "Penny", "Pete", "Porsha", "Preethi", "Preston", "Prisca", "Priscilla",
                "Quentin", "Quincy", "Quirinius",
                "Raja", "Rajiv", "Randall", "Randy", "Raphael", "Rapunzel", "Raul", "Raymond", "Reba", "Rebekah", "Reginald", "Renata", "Rex", "Rhet", "Richard", "Rigo", "Ringo", "Romeo", "Ronaldo", "Rosalind", "Rosemary", "Rufus", "Rumpelstiltskin", "Rusty",
                "Sabine", "Sabrina", "Sadie", "Salazar", "Sallyann", "Samantha", "Santina", "Santonio", "Sergeant", "Saruman", "Selena", "Seth", "Shamus", "Shane", "Sherlock",  "Sheva", "Sid", "Sidney", "Sisyphus", "Sonny", "Spidey", "Srinivas", "Stavros", "Stratton", "Stuart", "Suzie", "Sven",
                "Tangus", "Tanner", "Tanya", "Terrance", "Thaddeus", "Thatcher", "Theophilus", "Therousia", "Thomas", "Thor", "Trapezius", "Trevor", "Tsipi", "Tsiporah", "Tristan", "Trudy",
                "Uriah", "Ursula", "Uzziah", "Uzziel","Valenzuela", "Valkyrie", "Vashti", "Vitaliy", "Vito", "Vladimir",  "Wellington", "Winston", "Wyndham",
                "Xavier", "Xerxes", "Xian", "Yakob", "Yaroslav", "Yasmine", "Yochanan", "Yohanan", "Yosef", "Yu",
                "Zacchaeus", "Zaccheus", "Zachary", "Zander", "Zarathustra", "Zarephath", "Zebadiah", "Zechariah", "Zedekiah", "Zephaniah", "Zerubbabel", "Zhao", "Ziklag", "Zimri", "Zipporah", "Zoe", "Zophar", "Zsa Zsa"
            };
            return RandomSelect(fNames);
        }

        #endregion Small Set of First Names

        #region Female First Names

        public static string RandomizeFemaleFirstName()
        {

            string[] femaleNames = {
   "Aaliyah", "Aarushi", "Abbey", "Abbi", "Abbie", "Abby", "Abi", "Abia", "Abigail", "Aby", "Acacia",
   "Ada", "Adalia", "Adalyn", "Addie", "Addison", "Adelaide", "Adele", "Adelia", "Adelina", "Adeline",
   "Adreanna", "Adriana", "Adrianna", "Adrianne", "Adrienne", "Aeowynn", "Aerona", "Agatha", "Aggie",
   "Agnes", "Aida", "Aileen", "Aimee", "Aine", "Ainsleigh", "Ainsley", "Aisha", "Aisling", "Alaina",
   "Alana", "Alanis", "Alanna", "Alannah", "Alayah", "Alayna", "Alba", "Aleah", "Alecia", "Aleisha",
   "Alejandra", "Alena", "Alessandra", "Alessia", "Alex", "Alexa", "Alexandra", "Alexandria", "Alexia",
   "Alexis", "Alexus", "Ali", "Alia", "Alice", "Alicia", "Alina", "Alisa", "Alisha", "Alison", "Alissa",
   "Alivia", "Aliyah", "Alize", "Alka", "Allie", "Allison", "Ally", "Allyson", "Alma", "Alondra",
   "Alycia", "Alyshialynn", "Alyson", "Alyssa", "Alyssia", "Amalia", "Amanda", "Amani", "Amara",
   "Amari", "Amaris", "Amaya", "Amber", "Amelia", "Amelie", "America", "Amethyst", "Amie", "Amina",
   "Amirah", "Amy", "Amya", "Ana", "Anabel", "Anabelle", "Anahi", "Anais", "Anamaria", "Ananya",
   "Anastasia", "Andie", "Andrea", "Andromeda", "Angel", "Angela", "Angelia", "Angelica", "Angelina",
   "Angeline", "Angelique", "Angie", "Anika", "Anisa", "Anita", "Aniya", "Aniyah", "Anjali", "Ann",
   "Anna", "Annabel", "Annabella", "Annabelle", "Annabeth", "Annalisa", "Annalise", "Anne", "Anneke",
   "Annelisse", "Annemarie", "Annette", "Annie", "Annika", "Annmarie", "Anselma", "Anthea",
   "Antoinette", "Antonia", "Anuja", "Anusha", "Anya", "Aoibhe", "Aoibheann", "Aoife", "Aphrodite",
   "Apple", "April", "Aqua", "Arabella", "Aria", "Ariadne", "Ariana", "Arianna", "Arianne", "Ariel",
   "Ariella", "Arielle", "Arisha", "Arleen", "Arlene", "Artemis", "Arwen", "Arya", "Asha", "Ashanti",
   "Ashlee", "Ashleigh", "Ashley", "Ashlie", "Ashlyn", "Ashlynn", "Ashton", "Ashvini", "Asia", "Asma",
   "Aspen", "Astrid", "Athena", "Aubree", "Aubrey", "Audra", "Audrey", "Audrina", "Augustina",
   "Aurelia", "Aurora", "Autumn", "Ava", "Avalon", "Avery", "Avril", "Aya", "Ayana", "Ayanna", "Ayesha",
   "Ayisha", "Ayla", "Azalea", "Azaria", "Azariah", "Bailey", "Barbara", "Barbie", "Baylee", "Bea",
   "Beatrice", "Beatrix", "Becca", "Beccy", "Becky", "Belinda", "Bella", "Bellatrix", "Belle", "Benita",
   "Benthe", "Bernadette", "Bernice", "Bertha", "Beryl", "Bess", "Beth", "Bethan", "Bethanie",
   "Bethany", "Betsy", "Bettina", "Betty", "Beverly", "Beyonce", "Bhu", "Bianca", "Billie", "Blair",
   "Blaire", "Blake", "Blanche", "Bliss", "Bloom", "Blossom", "Blythe", "Bobbi", "Bobbie", "Bonita",
   "Bonnie", "Braelyn", "Brandi", "Brandy", "Braylee", "Brea", "Breanna", "Bree", "Breeze", "Brenda",
   "Brenna", "Bria", "Briana", "Brianna", "Brianne", "Briar", "Bridget", "Bridgette", "Bridie",
   "Briella", "Brielle", "Briley", "Brinley", "Briony", "Brisa", "Britney", "Britt", "Brittany",
   "Brittney", "Brogan", "Bronte", "Bronwen", "Bronwyn", "Bronwynn", "Brooke", "Brooklyn", "Brooklynn",
   "Bryanna", "Brylee", "Bryn", "Brynlee", "Brynn", "Bryony", "Bunty", "Cadence", "Cailin", "Caitlan",
   "Caitlin", "Caitlyn", "Caleigh", "Cali", "Callie", "Calliope", "Callista", "Calypso", "Cameron",
   "Cami", "Camila", "Camilla", "Camille", "Camryn", "Candace", "Candice", "Candy", "Caoimhe",
   "Caprice", "Cara", "Carina", "Caris", "Carissa", "Carla", "Carley", "Carlie", "Carly", "Carlynn",
   "Carmel", "Carmela", "Carmen", "Carol", "Carole", "Carolina", "Caroline", "Carolyn", "Carrie",
   "Carter", "Carys", "Casey", "Cassandra", "Cassia", "Cassidy", "Cassie", "Cat", "Cate", "Caterina",
   "Cathalina", "Catherine", "Cathleen", "Cathy", "Catlin", "Catrina", "Catriona", "Caye", "Cayla", "Cece",
   "Cecelia", "Cecilia", "Cecily", "Celeste", "Celestia", "Celestine", "Celia", "Celina", "Celine",
   "Cerys", "Chanel", "Chanelle", "Chantal", "Chantelle", "Charis", "Charissa", "Charisse", "Charity",
   "Charlene", "Charley", "Charlie", "Charlize", "Charlotte", "Charmaine", "Chastity", "Chelsea",
   "Chelsey", "Chenille", "Cher", "Cheri", "Cherie", "Cherry", "Cheryl", "Cheyanne", "Cheyenne",
   "Chiara", "Chloe", "Chris", "Chrissy", "Christa", "Christabel", "Christal", "Christen", "Christi",
   "Christiana", "Christie", "Christina", "Christine", "Christy", "Chrystal", "Ciara", "Cici", "Ciel",
   "Cierra", "Cindy", "Claire", "Clara", "Clarabelle", "Clare", "Clarice", "Clarissa", "Clarisse",
   "Clary", "Claudette", "Claudia", "Claudine", "Clea", "Clementine", "Cleo", "Clodagh", "Clover",
   "Coco", "Colette", "Colleen", "Connie", "Constance", "Cora", "Coral", "Coralie", "Coraline",
   "Cordelia", "Cori", "Corina", "Corinne", "Corra", "Cosette", "Courtney", "Cristina", "Crystal",
   "Cynthia", "Dagmar", "Dahlia", "Daisy", "Dakota", "Dana", "Danette", "Dani", "Danica", "Daniela",
   "Daniella", "Danielle", "Danika", "Daphne", "Dara", "Darcey", "Darcie", "Darcy", "Daria", "Darla",
   "Darlene", "Dashee", "Davida", "Davina", "Dawn", "Dayna", "Daysha", "Deana", "Deann", "Deanna",
   "Deanne", "Debbie", "Debora", "Deborah", "Debra", "Dee", "Deedee", "Deena", "Deidre", "Deirdre",
   "Deja", "Delaney", "Delanie", "Delia", "Delilah", "Della", "Delores", "Delphine", "Demetria", "Demi",
   "Dena", "Denise", "Denny", "Desiree", "Destinee", "Destiny", "Diamond", "Diana", "Diane", "Dianna",
   "Dianne", "Dido", "Dina", "Dionne", "Dior", "Dixie", "Dolly", "Dolores", "Dominique", "Donna",
   "Dora", "Doreen", "Doris", "Dorothy", "Dot", "Drew", "Dulce", "Eabha", "Ebony", "Echo", "Eden",
   "Edie", "Edith", "Edna", "Edwina", "Effie", "Eileen", "Eilidh", "Eimear", "Ekaterina", "Elaina",
   "Elaine", "Elana", "Eleanor", "Electra", "Elektra", "Elena", "Eliana", "Elin", "Elina", "Elisa",
   "Eliza", "Elisabeth", "Elise", "Eliza", "Elizabeth", "Ella", "Elle", "Ellen", "Ellery", "Ellie",
   "Ellis", "Elly", "Elodie", "Eloise", "Elora", "Elsa", "Elsie", "Elspeth", "Elvira", "Elysia",
   "Elyza", "Emanuela", "Ember", "Emely", "Emer", "Emerald", "Emerson", "Emilee", "Emilia", "Emilie",
   "Emily", "Emma", "Emmaline", "Emmalyn", "Emmanuelle", "Emmeline", "Emmie", "Emmy", "Enya", "Erica",
   "Erika", "Erin", "Eris", "Erzsébet", "Eryn", "Esmay", "Esme", "Esmeralda", "Esmerelda", "Esperanza",
   "Estee", "Estelle", "Ester", "Esther", "Estrella", "Ethel", "Eugenie", "Eunice", "Eva", "Evangeline",
   "Eve", "Evegeniya", "Evelin", "Evelyn", "Everly", "Evie", "Evita", "Fabrizia", "Faith", "Fallon",
   "Fanny", "Farah", "Farrah", "Fatima", "Fawn", "Fay", "Faye", "Felicia", "Felicity", "Fern",
   "Fernanda", "Ffion", "Fifi", "Fiona", "Fleur", "Flor", "Flora", "Florence", "Fran", "Frances",
   "Francesca", "Francine", "Frankie", "Freda", "Freya", "Frida", "Gabby", "Gabriela", "Gabriella",
   "Gabrielle", "Gail", "Galadriel", "Gayle", "Gaynor", "Geena", "Gemma", "Gena", "Genesis",
   "Genevieve", "Georgette", "Georgia", "Georgie", "Georgina", "Geraldine", "Gertrude", "Gia", "Gianna",
   "Gigi", "Gillian", "Gina", "Ginger", "Ginny", "Giovanna", "Gisela", "Giselle", "Gisselle",
   "Gladys", "Glenda", "Gloria", "Goldie", "Grace", "Gracelyn", "Gracie", "Grainne", "Greta",
   "Gretchen", "Griselda", "Guadalupe", "Guadelupe", "Guinevere", "Gwen", "Gwendolyn", "Gwyneth",
   "Habiba", "Hadassah", "Hadley", "Hailee", "Hailey", "Haleigh", "Haley", "Halle", "Hallie", "Hanna",
   "Hannah", "Harley", "Harmony", "Harper", "Harriet", "Hattie", "Hayden", "Haylee", "Hayley", "Hazel",
   "Hazeline", "Heather", "Heaven", "Heidi", "Helen", "Helena", "Helga", "Helina", "Henrietta",
   "Hepsiba", "Hera", "Hermione", "Hester", "Hetty", "Hilary", "Hilda", "Hollie", "Holly", "Honesty",
   "Honey", "Honor", "Honour", "Hope", "Hosanna", "Hyacinth", "Ianthe", "Ida", "Ila", "Ilene", "Iliana",
   "Ilona", "Ilse", "Imani", "Imelda", "Imogen", "India", "Indie", "Indigo", "Indira", "Ines", "Inga",
   "Ingrid", "Iona", "Ira", "Irene", "Iris", "Irma", "Isa", "Isabeau", "Isabel", "Isabella",
   "Isabelle", "Isha", "Isis", "Isla", "Isobel", "Isolde", "Itzel", "Ivana", "Ivanna", "Ivy", "Iyanna",
   "Izabella", "Izidora", "Izzy", "Jacinda", "Jacinta", "Jackie", "Jacqueline", "Jacquelyn", "Jada",
   "Jade", "Jaden", "Jadyn", "Jael", "Jaelynn", "Jaida", "Jaime", "Jamie", "Jamiya", "Jan", "Jana",
   "Janae", "Jancis", "Jane", "Janelle", "Janessa", "Janet", "Janette", "Janice", "Janie", "Janine",
   "Janis", "Janiya", "January", "Jaqueline", "Jasmin", "Jasmine", "Jaya", "Jayda", "Jayden", "Jayla",
   "Jaylinn", "Jaylynn", "Jayne", "Jazlyn", "Jazmin", "Jazmine", "Jean", "Jeanette", "Jeanine",
   "Jeanne", "Jeannette", "Jeannie", "Jeannine", "Jemima", "Jemma", "Jen", "Jena", "Jenae", "Jenessa", "Jenna",
   "Jenni", "Jennie", "Jennifer", "Jenny", "Jensen", "Jeri", "Jerri", "Jess", "Jessa", "Jesse",
   "Jessica", "Jessie", "Jet", "Jewel", "Jezebel", "Jill", "Jillian", "Jo", "Joan", "Joann", "Joanna",
   "Joanne", "Jocelyn", "Jodi", "Jodie", "Jody", "Joelle", "Johanna", "Joleen", "Jolene", "Jolie",
   "Joni", "Jordan", "Jordana", "Jordyn", "Jorja", "Joselyn", "Josephine", "Josie", "Joy", "Joyce",
   "Joyel", "Juanita", "Judith", "Judy", "Jules", "Julia", "Juliana", "Julianna", "Julianne", "Julie",
   "Juliet", "Juliette", "Julissa", "July", "June", "Juno", "Justice", "Justina", "Justine", "Kacey",
   "Kaidence", "Kailey", "Kailyn", "Kaitlin", "Kaitlyn", "Kaitlynn", "Kalea", "Kaleigh", "Kali",
   "Kalia", "Kamala", "Kamryn", "Kara", "Karen", "Kari", "Karin", "Karina", "Karissa", "Karla",
   "Karlee", "Karly", "Karolina", "Karyn", "Kasey", "Kassandra", "Kassidy", "Kassie", "Kat", "Katara",
   "Katarina", "Kate", "Katelyn", "Katelynn", "Katerina", "Katharine", "Katherine", "Kathleen",
   "Kathryn", "Kathy", "Katia", "Katie", "Katja", "Katlyn", "Katrina", "Katy", "Katya", "Kay", "Kaya",
   "Kaye", "Kayla", "Kaylee", "Kayleigh", "Kayley", "Kaylie", "Kaylin", "Keara", "Keeley", "Keely",
   "Keira", "Keisha", "Kelis", "Kelley", "Kelli", "Kellie", "Kelly", "Kelsey", "Kelsie", "Kendall",
   "Kendra", "Kennedy", "Kenzie", "Keri", "Kerian", "Kerri", "Kerry", "Keturah", "Kia", "Kiana",
   "Kiara", "Kiera", "Kierra", "Kiersten", "Kiki", "Kiley", "Kim", "Kimberlee", "Kimberley", "Kimberly",
   "Kimbriella", "Kimmy", "Kinley", "Kinsey", "Kinsley", "Kira", "Kirsten", "Kirstin", "Kirsty",
   "Kiswa", "Kitty", "Kizzy", "Kloe", "Kora", "Kori", "Kourtney", "Kris", "Krista", "Kristen", "Kristi",
   "Kristie", "Kristin", "Kristina", "Kristine", "Kristy", "Krystal", "Kyla", "Kylee", "Kyleigh",
   "Kylie", "Kyra", "Lacey", "Lacie", "Lacy", "Ladonna", "Laila", "Lakyn", "Lala", "Lana", "Laney",
   "Lani", "Lara", "Laralee", "Larissa", "Lateesha", "Latoya", "Laura", "Laurel", "Lauren", "Lauri",
   "Laurie", "Lauryn", "Lavana", "Lavender", "Lavinia", "Layla", "Lea", "Leah", "Leandra", "Leann",
   "Leanna", "Leanne", "Lee", "Leela", "Leena", "Leia", "Leigh", "Leila", "Leilani", "Lela", "Lena",
   "Lenore", "Leona", "Leonie", "Leora", "Lesa", "Lesley", "Leslie", "Lesly", "Leticia", "Lettie",
   "Lexi", "Lexia", "Lexie", "Lexis", "Lia", "Liana", "Lianne", "Libby", "Liberty", "Lidia", "Lila",
   "Lilac", "Lilah", "Lilian", "Liliana", "Lilita", "Lilith", "Lillian", "Lillie", "Lilly", "Lily",
   "Lina", "Linda", "Lindsay", "Lindsey", "Lindy", "Lisa", "Lisette", "Liv", "Livia", "Livvy", "Liz",
   "Liza", "Lizbeth", "Lizette", "Lizzie", "Lizzy", "Ljubliana", "Ljubljana", "Logan", "Lois", "Lola",
   "Lolita", "London", "Lora", "Loran", "Lorelei", "Loren", "Lorena", "Loretta", "Lori", "Lorie",
   "Lorna", "Lorraine", "Lorri", "Lorrie", "Lottie", "Lotus", "Louisa", "Louise", "Luann", "Lucia",
   "Luciana", "Lucie", "Lucille", "Lucinda", "Lucky", "Lucretia", "Lucy", "Ludmilla", "Luisa", "Lulu",
   "Luna", "Lupita", "Lydia", "Lyla", "Lyna", "Lynda", "Lyndsey", "Lynette", "Lynn", "Lynne",
   "Lynnette", "Lynsey", "Lyra", "Lyric", "Mabel", "Mabeline", "Macey", "Macie", "Mackenzie", "Macy",
   "Mada", "Madalyn", "Maddie", "Maddison", "Maddy", "Madeleine", "Madeline", "Madelyn", "Madison",
   "Madisyn", "Madyson", "Mae", "Maeve", "Magda", "Magdalena", "Magdalene", "Maggie", "Maia", "Maire",
   "Mairead", "Maisie", "Maisy", "Maja", "Makayla", "Makenna", "Makenzie", "Malia", "Malinda",
   "Mallory", "Malory", "Mandy", "Manuela", "Mara", "Marcela", "Marcella", "Marci", "Marcia", "Marcy",
   "Margaret", "Margarita", "Margie", "Margo", "Margot", "Margret", "Maria", "Mariah", "Mariam",
   "Marian", "Mariana", "Marianna", "Marianne", "Maribel", "Marie", "Mariela", "Marilyn", "Marina",
   "Marion", "Marisa", "Marisol", "Marissa", "Maritza", "Marjorie", "Marla", "Marlee", "Marlene",
   "Marley", "Marnie", "Marsha", "Martha", "Martina", "Mary", "Maryam", "Maryann", "Marybeth",
   "Matilda", "Maude", "Maura", "Maureen", "Mavis", "Maxine", "May", "Maya", "Mayra", "Mckayla",
   "Mckenna", "Mckenzie", "Mea", "Meadow", "Meagan", "Meera", "Meg", "Megan", "Meghan", "Mei", "Mei-li",
   "Mel", "Melanie", "Melikalikimaka", "Melina", "Melinda", "Melissa", "Melody", "Mercedes", "Mercy",
   "Meredith", "Merida", "Meryl", "Mia", "Michaela", "Michele", "Michelle", "Mika", "Mikaela",
   "Mikayla", "Mikhaela", "Mila", "Mildred", "Milena", "Miley", "Millicent", "Millie", "Milly", "Mimi",
   "Mina", "Mindy", "Minerva", "Minnie", "Mira", "Miranda", "Miriam", "Mirjam", "Misty", "Mitzi",
   "Moira", "Mollie", "Molly", "Mona", "Monica", "Monika", "Monique", "Montana", "Morgan", "Morgana",
   "Moya", "Murderess", "Muriel", "Mya", "Myfanwy", "Myla", "Myra", "Myrna", "Naama", "Nadene", "Nadia",
   "Nadine", "Nahaliel", "Naja", "Nala", "Nancy", "Nanette", "Naomi", "Natalia", "Natalie",
   "Natascha", "Natasha", "Natisha", "Naya", "Nayeli", "Nell", "Nellie", "Nelly", "Nena", "Nerissa",
   "Nessa", "Nevaeh", "Neve", "Nia", "Niamh", "Nichola", "Nichole", "Nicki", "Nicky", "Nicola",
   "Nicole", "Nicolette", "Nicolina", "Nieve", "Niki", "Nikita", "Nikki", "Nikolina", "Nila", "Nina",
   "Nishka", "Noelle", "Nola", "Nora", "Noreen", "Norma", "Nova", "Oasis", "Ocean", "Octavia", "Odalis",
   "Odele", "Odelia", "Odette", "Ofra", "Olga", "Olive", "Olivia", "Oonagh", "Opal", "Ophelia",
   "Ophra", "Orianna", "Orla", "Orlaith", "Ottavia", "Padme", "Page", "Paige", "Paisley", "Paloma",
   "Pam", "Pamela", "Pandora", "Pansy", "Paola", "Paris", "Patience", "Patrice", "Patricia", "Patsy",
   "Patti", "Patty", "Paula", "Paulette", "Paulina", "Pauline", "Payton", "Pearl", "Peggy", "Penelope",
   "Penny", "Perla", "Perrie", "Persephone", "Petra", "Petunia", "Peyton", "Phillipa", "Philomena",
   "Phoebe", "Phoenix", "Phyllis", "Piper", "Pippa", "Pixie", "Polly", "Poppy", "Porsche", "Porsha",
   "Portia", "Precious", "Preethi", "Presley", "Preslie", "Primrose", "Princess", "Prisca", "Priscilla",
   "Priya", "Promise", "Prudence", "Prue", "Queenie", "Quiana", "Quinn", "Rabia", "Rachael", "Rachel",
   "Rachelle", "Rae", "Raegan", "Raelyn", "Raina", "Raine", "Ramona", "Ramsha", "Randi", "Rani",
   "Rania", "Rapunzel", "Raquel", "Raven", "Raya", "Rayna", "Rayne", "Reagan", "Reanna", "Reanne",
   "Reba", "Rebecca", "Rebekah", "Reese", "Regan", "Regina", "Reilly", "Reina", "Remi", "Rena",
   "Renata", "Renate", "Rene", "Renee", "Renesmee", "Reyna", "Rhea", "Rhian", "Rhianna", "Rhiannon",
   "Rhoda", "Rhona", "Rhonda", "Ria", "Rianna", "Ricki", "Rihanna", "Rikki", "Riley", "Rita", "River",
   "Roanne", "Roberta", "Robin", "Robyn", "Rochelle", "Rocio", "Roisin", "Rolanda", "Ronda", "Roni",
   "Rosa", "Rosalie", "Rosalind", "Rosalynn", "Rosanna", "Rose", "Rosella", "Rosemarie", "Rosemary",
   "Rosetta", "Rosie", "Rosy", "Rowan", "Rowena", "Roxanne", "Roxie", "Roxy", "Rozlynn", "Ruby", "Rue",
   "Rusty", "Ruth", "Rydel", "Rylee", "Ryleigh", "Rylie", "Sabina", "Sabine", "Sabrina", "Sade",
   "Sadhbh", "Sadie", "Saffron", "Saffronia", "Safire", "Safiya", "Sage", "Sahara", "Saige", "Saira",
   "Sally", "Sallyann", "Salma", "Salome", "Sam", "Samantha", "Samara", "Samia", "Samira", "Sammie",
   "Sammy", "Sandra", "Sandy", "Santina", "Saoirse", "Sapphire", "Sara", "Sarah", "Sarina", "Sariya",
   "Sascha", "Sasha", "Saskia", "Savanna", "Savannah", "Scarlet", "Scarlett", "Sebastianne", "Selah",
   "Selena", "Selina", "Selma", "Senuri", "Seren", "Serena", "Serenity", "Shakira", "Shana", "Shania",
   "Shanice", "Shannon", "Shari", "Sharon", "Shauna", "Shawn", "Shawna", "Shawnette", "Shayla", "Shea",
   "Sheena", "Sheila", "Shelby", "Shelia", "Shelley", "Shelly", "Sheri", "Sheridan", "Sherri",
   "Sherrie", "Sherry", "Sheryl", "Sheva", "Shirley", "Shona", "Shreya", "Shyla", "Sian", "Sidney",
   "Sienna", "Sierra", "Silvia", "Simone", "Simran", "Sinead", "Siobhan", "Sky", "Skye", "Skylar",
   "Skyler", "Sloane", "Sofia", "Sofie", "Solange", "Sondra", "Sonia", "Sonja", "Sonya", "Sophia",
   "Sophie", "Sophy", "Stacey", "Staci", "Stacie", "Stacy", "Star", "Starla", "Stefanie", "Stella",
   "Steph", "Stephanie", "Sue", "Suki", "Summer", "Susan", "Susanna", "Susannah", "Susanne", "Susie",
   "Sutton", "Suzanna", "Suzanne", "Suzette", "Suzie", "Suzy", "Sybil", "Sydney", "Sylvia", "Sylvie",
   "Tabatha", "Tabitha", "Tahlia", "Tala", "Talia", "Taliyah", "Tallulah", "Tamara", "Tamera", "Tami",
   "Tamia", "Tamika", "Tammi", "Tammie", "Tammy", "Tamra", "Tamsin", "Tania", "Tanisha", "Tanya",
   "Tara", "Taryn", "Tasha", "Tatiana", "Tatum", "Tawana", "Taya", "Tayla", "Taylah", "Tayler",
   "Taylor", "Teagan", "Teegan", "Tegan", "Tenille", "Teresa", "Teri", "Terri", "Terrie", "Terry",
   "Tess", "Tessa", "Thalia", "Thea", "Thelma", "Theodora", "Theophilia", "Theresa", "Therese",
   "Therousia", "Thomasina", "Tia", "Tiana", "Tiffany", "Tilly", "Tina", "Toni", "Tonia", "Tonya",
   "Tori", "Tracey", "Traci", "Tracie", "Tracy", "Tricia", "Trina", "Trinity", "Trish", "Trisha",
   "Trista", "Trixie", "Trixy", "Trudy", "Tsipi", "Tsiporah", "Tyra", "Ulli", "Ulrica", "Ulrike", "Uma",
   "Una", "Ursula", "Valarie", "Valentina", "Valeria", "Valerie", "Vanessa", "Vashti", "Veda",
   "Velma", "Venetia", "Venus", "Vera", "Verity", "Veronica", "Vicki", "Vickie", "Vicky", "Victoria",
   "Viola", "Violet", "Virginia", "Vivian", "Viviana", "Vivien", "Vivienne", "Vonda", "Wallis", "Wanda",
   "Waverley", "Wendi", "Wendy", "Whitney", "Wilhelmina", "Willow", "Wilma", "Winnie", "Winnifred",
   "Winona", "Winter", "Xanthe", "Xaviera", "Xena", "Xia", "Ximena", "Xochil", "Xochitl", "Yasmin",
   "Yasmine", "Yazmin", "Yelena", "Yesenia", "Yolanda", "Ysabel", "Yulissa", "Yvaine", "Yvette",
   "Yvonne", "Zada", "Zaheera", "Zahra", "Zaira", "Zakia", "Zali", "Zara", "Zarephath", "Zaria", "Zaya",
   "Zayla", "Zelda", "Zelida", "Zelina", "Zena", "Zendaya", "Zia", "Zina", "Zipporah", "Ziva", "Zoe",
   "Zoey", "Zola", "Zora", "Zoya", "Zsa Zsa", "Zula", "Zuri", "Zyana"
                };


            return RandomSelect(femaleNames);
        }

        #endregion Female First Names

        #region Male First Names

        public static string RandomizeMaleFirstName()
        {
            string[] maleNames = db.Names.Where(fn => fn.Gender == CommonStrings.gMale).Select(fn => fn.Value).ToArray();

            return RandomSelect(maleNames);
        }

        #endregion Male First Names

        #region Unisex Names
        public static string RandomizeUxFirstName()
        {
            string[] uxNames =
            {
                "Agamous", "Ainsley", "Agonous", "Ashley", "Ashton", "Aubrey", "Avery", "Bailey", "Blake",
                "Brinley", "Brogan", "Cameron", "Carter", "Casey", "Charlie", "Chartreuse", "Chaz", "Chocolate",
                "Darcy", "Deon", "Ellis", "Emerson", "Festivus", "Finical", "Frankie", "Fusty", "Ghee", "Goose",
                "Greedo", "Grimace", "Hades", "Harley", "Hayden", "Hosanna", "Jackie", "Jaden", "Jaime",
                "Jamie", "Jasper", "Jayden", "Jensen", "Kennedy", "Lynn", "Morgan", "Nahaliel", "Ovaltine",
                "Pat", "Patsy", "Patty", "Reilly", "Riley", "River", "Rene", "Robin", "Rusty", "Scurvy",
                "Taylor", "Terry", "Valkyrie", "Yowza", "Zarathustra", "Zarephath", "Zsa Zsa"
            };
            return RandomSelect(uxNames);
        }
        #endregion Unisex Names

        #endregion First Name

        #region Last Name

        public static string RandomizeLastName()
        {
            string[] lNames =

            {
                "Abderian", "Abbassian", "Abbott", "Abcede", "Abdallah", "Abdicatious", "Abercrombie", "Abnormal", "Abnormous", "Abrew", "Abrogate", "Absurd", "Accipitrine", "Accoucheur", "Acosmist", "Acouasm", "Acoucheuse", "Acrid", "Acrimonious", "Acrocephalic", "Acuff", "Adiobalist", "Aeolist", "Aflunters", "Agamous", "Agonous", "Agroof", "Alameda", "Altiloquent", "Alvarez", "Amidala", "Anonymous", "Ante-Jentacular", "Anthropoglot", "Antilles", "Applecrisp", "Apostrophe", "Arctophilist", "Armitraj", "Aurophobe", "Avaricious", "Avetrol",
                "Babaganoush", "Babblington", "Babcock", "Bacillophobe", "Bachelor", "Backgammon", "Badot", "Baffoon", "Bagatelle", "Baggins", "Bagpiper", "Baker", "Ballicatter", "Ballista", "Bandolero", "Banichek", "Barbacoa", "Barbarous", "Barbosa", "Barnes", "Barnfather", "Bearclaw", "Beelzebul", "Beitelspacher", "Bernhardt", "Bleeth", "Bono", "Boondoggle", "Bourgeois", "Bourne", "Brambleberry", "Bratislava", "Breckneck", "Brewster", "Brodax", "Brutish", "Bubbleblower", "Buttersnaps",
                "Caballero", "Cabeza", "Calaway", "Calderone", "Callowitz", "Calrissian", "Calzone", "Campalong", "Cannelloni", "Capistrano", "Carney", "Carthief", "Catastrophe", "Chasuble", "Chatterly", "Chiapet", "Chudderly", "Chupacabra", "Cityslicker", "Clandestine", "Clap Yo Handz", "Clarendon", "Clezby", "Cloverton", "Cobbler", "Cobblestone", "Coddington", "Colossal", "Comatose", "Connery", "Copperfield", "Corduroy", "Cranmer",
                "Daft", "Damsell", "Danforth", "Daugherty", "Dauncey", "Dauncey-Paunts", "De Jong", "De Vries", "Demure", "Depp", "Deville", "Dingham", "Disher", "Doddlington", "Doodah", "Doolittle", "Dowager", "Downton", "Dubrovnik", "Duckmaster", "Dubstep", "Dunderton", "Dunham",
                "Ecclesiophobe", "Eckelstein", "Ectomorphic", "Effulgent", "Einstein", "Emetophobe", "Emmentaler", "Endomorphic", "Enigmatic", "Enigmatologist", "Epstein", "Eroteme", "Erythrophobe", "Etchingham", "Etton", "Euonym", "Evanescence", "Evanescent", "Ewok", "Exiguous", "Exsibilation", "Exum",
                "Falafel", "Fallacious", "Farmboy", "Featherduster", "Feldspar", "Fennyman", "Fett", "Feversham", "Flart", "Flartington", "Flattybouch", "Flingham", "Fogalot", "Fogbottom", "Forth", "Froggenthroat", "Fudgeon", "Funkmeister", "Fustilarion",
                "Gaberlunzie", "Galeophobe", "Galligantus", "Gingersnaps", "Gingham", "Giovanni", "Giovannini", "Gleason", "Goodenuff", "Grimtalker", "Grinswide", "Grommit", "Guster", "Guttersnype",
                "Hackysack", "Hadeharia", "Haggard", "Haggersnash", "Halitosis", "Hamartiologist", "Hamirostrate", "Harmonica", "Hasenpfeffer", "Hauer", "Haversham", "Hawksworth", "Hayseed", "Heehaw", "Henshawe", "Himmelsteiger", "Hitchcock", "Hogwylde", "Hollabackatcha", "Holleratcha", "Hollerslightly", "Holmes", "Holschtein", "Hooligan", "Hopalong", "Hornblower", "Huckster", "Huderon", "Husseyfuth", "Husseyton", "Hurlyburly", "Huxtable", "Huxter",
                "Iconoclast", "Illeist", "Imberbic", "Immerded", "Impecunious", "Indahouse", "In-the-Woods",
                "James", "Jeeter", "Jejunator", "Jettatore", "Jingleheimer-Schmidt", "Jones", "Jumentous",
                "Kamehameha", "Karabambuchi", "Keckilpenny", "Killingsworth", "Kim", "Klebenleiber", "Klein", "Klicketyclack", "Klinker", "Knick Knack", "Knivetton", "Koesler", "Kravitz",
                "Lao", "Lassiter", "Latimer", "Lee", "Leviston", "Levitz", "Litchfield", "Liverich", "Logogogue", "Lovingood", "Lucifogous", "Lucubrator", "Lumbardy", "Lychnobite",
                "MacIntosh", "Maledicent", "Malmquist", "Martext", "Mayflower", "Mayelemann", "McGee", "McToc...", "Middleton", "Misarchist", "Monk", "Moody", "Mortified", "Mullarky", "Mumford", "Munroe", "Muskox", "Muzhik",
                "Narcissus", "Nash", "Nickerbacher", "Nimrod", "Nurk",
                "O'Malley", "O'Reilly", "Ogletree", "Overton",
                "Pachyderm", "Pacifier", "Paleaceous", "Pandemic", "Pandemonium", "Paradox", "Parataxis", "Parsimonious", "Patrician", "Peacemaker", "Peacock", "Pedantic", "Pelletoot", "Pemberton", "Pennywhistle", "Peppercorn", "Perfidious", "Perilous", "Pernicious", "Perrot", "Philanthropist", "Placid", "Poepjes", "Poppycock", "Portentous", "Pottytock", "Pownder", "Pragmatic", "Precarious", "Preposterous", "Prowd", "Pterodactyl", "Pugilist", "Pugnacious", "Pungent", "Purles", "Purloiner", "Purlykat", "Pursglove", "Pyroclastic",
                "Qabalah", "Quacky", "Quadratic", "Quaker", "Quarrelsome", "Quarterpownder", "Quasar", "Queenly", "Quellington", "Quetzal", "Quibble", "Quirky", "Quixote",
                "Raintree", "Rampallion", "Rejoice", "Richman", "Richmond", "Ridley", "Ringham", "Rippingham", "Robinson", "Rondeau", "Rotmensen",
                "Sandoval", "Sandwalker", "Saynesberry", "Scraggleton", "Scroggs", "Scoundrel", "Scrooge", "Scullion", "Sequestered", "Shiveley", "Shivers", "Singham", "Singalong", "Singleton", "Skubalon", "Skywalker", "Sloth", "Sluggard", "Smacktalker", "Smuggins", "Snitch", "Solo", "Soupdribbler", "Spaans", "Spencer", "Stewart", "Stinkard", "Stottelmeyer", "Strangewayes", "Stubbington", "Stubby", "Swashbuckler",
                "Tang", "Teeger", "Thistleton", "Throckmorton", "Ting", "Thursty", "Toothy", "Torrington", "Torvalds", "Triumphant", "Troutslayer", "Trumpington", "Tweedy", "Tweedybyrd",
                "Underhill", "Underdale", "Underton",
                "Van Helsing", "Vicious", "Villainous", "Von Richtofen",
                "Wallahwallah", "Weaselchops", "Whiplash", "Whistlewhetter", "Whittlebury", "Wildebeest", "Williams", "Winebibber", "Wingham", "Wiseacre", "Witherspoon", "Wonbat", "Woodybrygg", "Woolycott", "Wormwood",
                "Yamaguchi", "Yamamoto", "Yang", "Yarmulke", "Yazzie", "Yelverton", "Ying", "Yolo",
                "Zamboni", "Zeldenthuis", "Zelotes"
            };



            return RandomSelect(lNames);
        }

        #endregion Last Name

        #region Date of Birth
        public static DateTime RandomizeDateOfBirth(int minAge = 18, int maxAge = 26)
        {
            int year = DateTime.Now.AddYears(-(GetRandomNumberBetween(minAge, maxAge))).Year;
            int month = GetRandomNumberBetween(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, day);
        }
        #endregion Date of Birth

        #region Email Address

        public static string MakeFakeEmailAddress(string fn, string ln, string domain = @"@email.arizona.test")
        {
            return MakeFakeNetId(fn, ln) + domain;
        }

        public static string MakeAlternateEmailAddress(string fn, string ln, string domain = @"@alternate.email")
        {
            return fn.ToLower() + "." + ln.ToLower() + domain;
        }

        #endregion Email Address

        #region Street Address
        public static string RandomizeAddress()
        {
            #region Directions, Streets, and Type Formats

            string[] direction = { "North", "South", "East", "West", "N", "S", "E", "W" };

            string[] street =
            {
                "Albatross", "Appaloosa", "Mangrove", "Pontatoc", "Cheshire", "Cardiff", "Hollywood", "Hereford",
                "Kleindale", "Michigan", "Sunset", "Sunrise", "Moonlight", "Wuthering Heights", "Aspen",
                "Cherry Blossom", "Orange Grove", "Midnight", "Secret Passageway", "Crankshaft", "Cloverfield",
                "Moccasin", "Barracuda", "Hedgehog", "Wallaby", "Baskerville", "Pagliacci", "Valkyrie",
                "Tuscaloosa", "Jimminy Cricket", "Thundercat", "Ironside", "Prometheus", "Neptune",
                "Hantavirus", "Nick Nack", "Honeysuckle", "Beanblossom", "Mud Lick", "Coppersmith", "Prairie Dog",
                "Crawley", "Death Trap", "Large Wooden Badger", "Holy Hand Grenade", "Camelot", "Sir Bedevere",
                "Black Knight", "Lobster Trap", "Cheese Shoppe", "Bloody Peasant", "Danger", "Skullduggery",
                "Coconuts", "Indefatigable", "Partisan", "Vorpal Bunny", "Rabbit of Caerbannog", "Balsamic",
                "Thyme", "Rosemary", "Spangled Drongo", "Ruffed Grouse", "Lesser Prairie-Chicken",
                "Arctic Loon", "Flamingo", "Himalayan Snowcock", "Wandering Albatross", "Sooty Shearwater",
                "Blue-Footed Booby", "Magnificaent Frigatebird", "Great Blue Heron", "Blue-Throated Tiger Bittern",
                "Snowy Egret", "White Ibis", "Black-Crowned Night Heron", "Big Year", "Harrier", "Goshawk",
                "Swallow-Tailed Kite", "Hook-Billed Kite", "Kestrel", "Klapperschlange", "Toxic Iguana",
                "Rough-Legged Hawk", "Red-Footed Falcon", "Clapper Rail", "Corn Crake", "Eurasian Coot",
                "Whooping Crane", "European Golden Plover", "Sandpiper", "Whimbrel", "Redshank",
                "Wandering Tattler", "Jack Snipe", "Black Noddy", "Whiskered Tern", "Yellow-Bellied Sapsucker",
                "Scaly-Naped Pigeon", "Snowy Owl", "Whiskered Screech Owl", "Pygmy Owl", "Lingering Lizard",
                "Whip-poor-will", "Gray Nightjar", "Mango", "Eurasian Jackdaw", "Doting Donkey", "Hillbilly",
                "Nutcracker", "Pinyon Jay", "Fish Crow", "Blue-Winged Warbler", "Scarlet Tanager",
                "Swamp Sparrow", "Eurasian Bullfinch", "Spangled Starling", "Bearscat", "Haberdashery",
                "Wistful Wolverine", "Blistering Barnacles", "Bubbling Billabong", "Tea Tree",
                "Bay of Bengal", "Wild Goosechase", "Ugly Duckling", "Nursery Rhyme", "Luau", "Inspiration",
                "Woolly Mammoth", "Sabertoothed Squirrel", "Scarlet Pumpernickel", "Tungsten", "Dynamite"
            };


            string[] format = { "Ave", "Avenue", "Rd", "Road", "St", "Street", "Blvd", "Boulevard", "Way", "Trl", "Trail", "Cir", "Circle", "Pl", "Place", "Tpke", "Turnpike", "Ct", "Court", "Dr", "Drive", "Expy", "Expressway", "Route", "Rte", "Freeway", "Fwy", "Junction", "Jct", "Lane", "Ln", "Pkwy", "Parkway", "Stra", "Stravenue" };


            #endregion Directions, Streets, and Type Formats

            return GetRandomNumberBetween(1, 99999) + " " + RandomSelect(direction) + " " + RandomSelect(street) + " " + RandomSelect(format);
        }
        #endregion Street Address

        #region City
        public static string RandomizeCity()
        {
            string[] cities =
            {
                // Abbey, Alp(s), Angle, Apex, Arch(es), Ascent
                "Abandoned Archipelago", "Abilene", "Albany", "Astoria", "Athens", "Aurora", "Austin", "Avondale",
                // Badlands, Base, Basin, Bay, Beach, Bend, Bight, Bluff, Bog, Bolson, Bridge, Brook, Brow, Bulge, Butte
                "Badger Bend", "Badgerville", "Bagdad", "Banff", "Bangkok", "Banker's Basin", "Banshee Springs", "Batholith Basin", "Battle Creek", "Bauxite",
                "Beartrap Bluff", "Beaumont", "Bedrock", "Belgravia", "Berlin", "Bickering Butte", "Billings", "Biotite Bight", "Birmingham", "Black Basin",
                "Blackpool", "Bloomingdale", "Bloomington", "Bodacious Badlands", "Bolson", "Boomerang Bluff", "Boondoggle Bog", "Boring", "Boulder",
                "Brambleberry", "Bramblebush", "Bruges", "Bumblebee", "Buxton",
                // Camp, Canal, Canyon, Cape, Castle, Cathedral, Cave, Center, Centre, Chaparral, Church, Circle, Cistern, City, Cleft, Cliff, College, Corner, Crag, Crater, Crease, Creek, Crest, Crinkle, Crock, Croft, Crook, Curve
                "Cackling Cauldron", "Calamine", "Calamity Cliffs", "Calamity Creek", "Calcite", "Caldera Cauldron", "Caldera Creek", "Caliche Creek", "Capernaum",
                "Cape Cretaceous", "Capitol Reef", "Carbonite Cauldron", "Carnivore Canyon", "Castleton", "Chalcedon", "Chalky Chaparral", "Chelmsford", "Chesterfield", "Chichester",
                "Chico", "Chinle", "Clifton", "Colchecter", "Cowboy's Clutch", "Crackerville", "Crater Creek", "Creepy Hollow", "Cretaceous Cliff",
                "Cretaceous Creek", "Croydon", "Crumbling Crock",
                // Dam, Delta, Divide, Dome, Drift, Dune(s), Dyke
                "Davidic Drift", "Delirium Dunes", "Deposition Delta", "Deposition Dunes", "Desert Doldrums", "Destitute Divide", "Devon", "Dodge City", "Dory's Duldrums", "Dover",
                "Downton", 
                // Eddy, Elevation, Esker, Estuary
                "Eccentric Eddy", "Edelweiss Estuary", "Encino", "Eureka", 
                // Falls, Farm, Fault, Fen, Fjord, Floodplain, Fold, Fork, Fort, Fountain, Funnel, Furrow
                "Fishbarrel", "Floodplains", "Fraggle Rock", 
                // Gallery, Gap, Garden(s), Gate, Gradient, Groove, Grove
                "Glacier Springs", "Gloucester", "Golgotha", "Gotham City", "Grasshopper Grove", "Gypsy Camp",
                // Hamlet, Harbour, Heading, Headland(s), Heap, Height(s), Highland(s), Hill(s), Hillside, Hilltop, Hook, Horn, House, Hummock
                "Hambone Headlands", "Happy Acres", "Happy Valley", "Hartford", "Hazard Hills", "Hazzard", "Hermits Rest", "Hicksville", "Hijinx Hills",
                "Holland's Landing", "Hoolihan's Hamlet", "Horrific Hamlet", "Houston", "Huddleston",
                // Ice Cave(s), Igloo, Incline, Island
                "Incinerator Springs", "Inferno Canyon", 
                // Joist, Juggernaut
                "Jefferson", "Jerome",
                // Kettle, Knoll
                "Kaibeto", "Kayenta", "Kickapoo", "Kingston",
                // Lagoon, Lake, Lean, Lee, Line, Loop
                "Landslide", "Limedale", "Lincoln", "Loafer Springs",
                // Memorial, Mesa, Mill, Monument, Moraine, Mound, Mount, Mountain
                "Madras", "Madrid", "Manchester", "Maranatha", "Mayberry", "Metropolis", "Miami", "Milford", "Milwaukee", "Monkey's Eyebrow", "Moscow",
                "Mosquitoville", "Munson", "Murietta",
                // N
                "Naples", "New Hampton", "Newhaven", "Newmarket", "Noodleville", "Nut Plantation",
                // Obelisk
                "Oakland", "Oberlin", "Oceanside", "Odessa", "Ogletree", "Ontario", "Orangevale", "Oro Valley", "Oxbow", "Oxford", "Oxnard",
                // Palace, Parapet, Park, Pass, Peak(s), Pinnacle, Pitch, Plain, Plateau, Pond, Prairie, Precipice, Priory, Pyramid
                "Patagonia", "Peach Tree", "Peekaboo Prairie", "Peoria", "Pitchfork", "Prague", "Prince Rupert", "Promontory", "Pumpkin Patch",
                // Ranch, Range, Reach, Reef, Reserve, Reservior, Ridge, Rill, Rift, Rimple, Rise, Rivel, River, Rivulet, Rock, Round, Ruck, Ruins, Runoff
                "Ragnar's Rivulet", "Rattlesnake Bend", "Reading", "Redding", "Red River Valley", "Riddick's Rill",
                // Sag, Sands, Sea, Seam, Shift, Shore, Sill, Silurian, Sinkhole, Slope, Slump, Spine, Squall, Square, Station, Statue, Stream, Strip, Summit
                "San Antonio", "San Diego", "San Fernando", "San Gabriel", "Santa Barbara", "Santa Cruz", "Scary Woods", "Sewer City", "Sierra Vista",
                "Silly City", "Silver Spur", "Sleepy Hollow", "Slick Rock", "Smallville", "Square Butte", "Squatterville", "Squatting Peaks", "Steamboat",
                "St. Augustine", "St. Crispin", "St. David", "St. George", "St. Jerome", "St. John", "St. Justin", "St. Michael", "St. Stephen", "St. Thomas",
                // Tack, Talus, Temple, Tilt, Tomb, Tower, Triassic, Trough, Turn
                "Temecula", "Tigerlilly", "Tillamook", "Tomahawk", "Trinidad", "Tucson", "Tulip Town", "Turkey Vulture Terrace", "Twin Falls",
                // Upland
                "Utica", "Ulysses Upland",
                // Valley, Veer, Volcano
                "Vacuum Valley", "Valhalla", "Venice", "Ventura", "Very Unlikely", "Vortex Valley",
                // Wall, Wash, Waterfall, Weave, Wetland, Wheel, Woodland, Wrinkle
                "Weaver's Wash", "Westminster", "Whimsical Wash", "Whitehorse", "Winnipeg", "Winston's Wetland", "Woodland Park", "Wyatt's Wash",
                // Yardang, Yaw
                "Yarmouth", "Youngstown",
                // Zenith, Zigzag
                "Zeus' Zenith", "Ziklag"
            };

            return RandomSelect(cities);
        }

        public static string FabricateCityName()
        {
            string[] Modifier = db.CityModifiers.Select(cm => cm.Value).ToArray();

            string[] Substantive =
            {
                "Abbey", "Alp", "Alps", "Angle", "Apex", "Arch", "Arches", "Ascent",
                "Badlands", "Backwoods", "Base", "Basin", "Bay", "Beach", "Bend", "Bight", "Bluff", "Bog", "Bolson",
                "Boondocks", "Bridge", "Brook", "Brow", "Bulge", "Bush", "Butte",
                "Camp", "Canal", "Canyon", "Cape", "Castle", "Cathedral", "Cave", "Center", "Centre", "Chaparral",
                "Church", "Circle", "Cistern", "City", "Cleft", "Cliff", "Creek", "Crescent",
                "Dam", "Delta", "Divide", "Dome", "Drift", "Duldrums", "Dune", "Dunes", "Dyke",
                "Eddy", "Elevation", "Enclosure", "Esker", "Estuary",
                "Falls", "Farm", "Fault", "Fen", "Field", "Fjord", "Floodplain", "Fold", "Forest", "Fork", "Fort",
                "Fountain", "Frying Pan", "Funnel", "Furrow",
                "Gallery", "Gap", "Garden", "Gardens", "Gate", "Gradient", "Green", "Groove", "Grove",
                "Hamlet", "Harbour", "Heading", "Headland", "Headlands", "Heap", "Heath", "Height", "Heights",
                "Highland", "Highlands", "Hill", "Hills", "Hillside", "Hilltop", "Hinterland", "Hollow", "Hook",
                "Horn", "House", "Hummock",
                "Ice Cave", "Ice Caves", "Igloo", "Incline", "Island", "Isthmus",
                "Jackpot", "Jail", "Jetty", "Jog", "Joint", "Joola", "Joust", "Jump", "Jungle",
                "Keel", "Keep", "Kettle", "Key", "Kiln", "Kingdom", "Kitchen", "Knee", "Knoll", "Knot",
                "Lagoon", "Lake", "Lea", "Lean", "Lee", "Line", "Look", "Loop", "Lowland",
                "Meadow", "Memorial", "Mesa", "Melting Pot", "Mill", "Mission", "Moat", "Molehill", "Monument",
                "Moorland", "Moraine", "Mound", "Mount", "Mountain", "Mud-puddle",
                "Neck", "Needle", "Nest", "Nexus", "Nose", "Nook", "Niche", "Nub",
                "Oak", "Obelisk", "Oceanside", "Orchard", "Outback", "Overlook",
                "Palace", "Parapet", "Park", "Pass", "Pasture", "Patch", "Peak", "Peaks", "Pinnacle", "Pitch",
                "Plain", "Plantation", "Plateau", "Plot", "Pond", "Prairie", "Precipice", "Priory", "Pyramid",
                "Quarrel", "Quadrant", "Quarter", "Quay", "Quagmire", "Queue",
                "Ranch", "Range", "Reach", "Reef", "Reserve", "Reservior", "Ridge", "Rill", "Rift", "Rimple", "Rise"
                , "Rivel", "River", "Rivulet", "Rock", "Round", "Ruck",
                "Sag", "Sands", "Savanna", "Sea", "Seam", "Shift", "Shore", "Sieve", "Sill", "Sinkhole", "Slope",
                "Slump", "Spatula", "Spine", "Squall", "Square", "Station", "Statue", "Steppe", "Stream", "Strip",
                "Summit", "Swamp",
                "Tack", "Talus", "Temple", "Thicket", "Tilt", "Tomb", "Tower", "Trail", "Trough", "Turn",
                "Upland", "Uplands", "U-turn",
                "Valley", "Veer", "Veldt", "Vineyard", "Volcano", "Vestibule",
                "Wall", "Wash", "Waterfall", "Weave", "Wetland", "Wheel", "Wood", "Woodland", "Wrinkle",
                "Yardang", "Yaw",
                "Zenith", "Zigzag"
            };
            return RandomSelect(Modifier) + " " + RandomSelect(Substantive);
        }
        #endregion City

        #region State
        public static string RandomizeState()
        {
            string[] states = { "AA", "AE", "AK", "AL", "AP", "AR", "AS", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MP", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY" };
            return RandomSelect(states);
        }
        #endregion State

        #region Zip
        public static string RandomizeZip()
        {
            var x = GetRandomNumberBetween(1, 99999);
            //var x = DateTime.Now.Millisecond;
            return x.ToString("D5");
        }
        #endregion Zip

        #region NetId
        public static string RandomizeNetId(string fname, string lname, string s = "guest")
        {
            return GetRandomNumberBetween(0, 1000) % 2 == 1 ? MakeFakeNetId(fname, lname) : s;
        }
        #endregion NetId

        #region EmplId
        public static string RandomizeEmplId()
        {
            var num = GetRandomNumberBetween(1, 99999999);
            return num.ToString("D8");
        }
        #endregion EmplId

        #region US Phone Number

        public static string RandomizePhoneNumber_US(int areaCode = 520)
        {
            var pn = areaCode + GetRandomNumberBetween(1, 9999999).ToString("D7");
            return pn;
        }

        #endregion US Phone Number

        #endregion User Details

        #region Utilities

        #region Boolean

        public static Boolean GetRandomBoolean()
        {
            return GetRandomNumberBetween(1, 100) % 2 == 0;
        }

        public static Boolean GetOppositeBoolean(bool b)
        {
            return b != true;
        }

        #endregion Boolean

        public static string GetRandomPCN()
        {
            var x = GetRandomNumberBetween(1, 99999);
            return x.ToString("D5");
        }

        public static double GetRandomFtePercentage()
        {
            double[] fteDoubles = { 1.00, 0.75, 0.50, 0.25 };
            return RandomSelect(fteDoubles);
        }

        public static double GetRandomSalary()
        {
            var x = GetRandomNumberBetween(1, 999999);
            return Convert.ToDouble(x.ToString());
        }

        public static int GetRandomNumberBetween(int min = 0, int max = 100)
        {
            var x = new CryptoRandom();
            if (min > max)
                throw new ArgumentOutOfRangeException(min.ToString() + ">" + max.ToString());
            return x.Next(min, max);
        }

        public static long GetRandomLongBetween(long min = 0, long max = 999999999999999)
        {
            var x = new CryptoRandom();
            return x.NextLong(min, max);
        }

        public static string RandomSelect(string[] arr)
        {
            return arr[GetRandomNumberBetween(0, arr.Count() - 1)];
        }

        public static char RandomSelect(char[] arr)
        {
            return arr[GetRandomNumberBetween(0, arr.Count() - 1)];
        }

        public static double RandomSelect(double[] arr)
        {
            return arr[GetRandomNumberBetween(0, arr.Count() - 1)];
        }

        public static string RemoveSpaces(string s)
        {
            return Regex.Replace(s, @"\s", "");
        }

        public static string RemoveExtraStuff(string s)
        {
            return Regex.Replace(s, @"[\s\r\n';:!\.]", "");
        }

        public static string MakeFakeNetId(string fn, string ln)
        {
            try
            {
                return fn.ToLower()[0] + RemoveExtraStuff(string.Format(ln).ToLower());
            }
            catch
            {
                return "jdoe";
            }
        }

        public int ReturnIntForState(string stateCode)
        {
            return States.ContainsKey(stateCode) ? States[stateCode] : 0;
        }

        #endregion Utilities

        #region Excuses for Delays

        public static string RandomizeExcuseForDelay()
        {
            string[] excuses =
                {
                    "Overseas intersnship",
                    "Trade school apprenticeship",
                    "Humanitarian aid opportunity",
                    "Crisis with family business",
                    "Unable to establish residency"
                };
            return RandomSelect(excuses);
        }

        #endregion Excuses for Delays

        #region Random comment

        /// <summary>
        /// Deftly absconded from the Shakespearean insult kit (http://www.pangloss.com/seidel/shake_rule.html)
        /// </summary>
        /// <returns></returns>
        public static string GetRandomComment()
        {
            const string part1 = "Oh, thou ";
            string[] part2 =
            { "artless", "bawdy", "beslubbering", "bootless", "burly-boned", "caluminous", "churlish", "clouted", "cockered", "craven", "cullionly", "currish", "dankish", "dissembling", "droning", "errant", "fawning", "fishified", "fobbing", "frothy", "froward", "fusty", "gleeking", "goatish", "gorbellied", "impertinent", "infectious", "jarring", "loggerheaded", "lumpish", "mammering", "mangled", "mewling", "misbegotten", "odiferous", "paunchy", "poisonous", "pribbling", "puking", "puny", "qualling", "rank", "reeky", "roguish", "ruttish", "saucy", "spleeny", "spongy", "surly", "tottering", "unmuzzled", "vain", "venomed", "villainous", "warped", "wart-necked", "wayward", "weedy", "wimpled", "yeasty"
            };

            string[] part3 =
            { "base-court", "bat-fowling", "beef-witted", "beetle-headed", "boil-brained", "brazen-faced", "bunch-back'd", "clapper-clawed", "clay-brained", "common-kissing", "crook-pated", "dismal-dreaming", "dizzy-eyed", "doghearted", "dread-bolted", "earth-vexing", "elf-skinned", "fat-kidneyed", "fen-sucked", "flap-mouthed", "fly-bitten", "folly-fallen", "fool-born", "full-gorged", "guts-griping", "half-faced", "hasty-witted", "hedge-born", "hell-hated", "idle-headed", "ill-breeding", "ill-nurtured", "knotty-pated", "leaden-footed", "lily-livered", "malmsey-nosed", "milk-livered", "motley-minded", "muddy-mettled", "onion-eyed", "pigeon-liver'd", "plume-plucked", "pottle-deep", "pox-marked", "rampallian", "reeling-ripe", "rough-hewn", "rude-growing", "rump-fed", "scale-sided", "scurvy-valiant", "shard-borne", "sheep-biting", "spur-galled", "swag-bellied", "tardy-gaited", "tickle-brained", "toad-spotted", "unchin-snouted", "unwash'd", "weather-bitten", "whoreson"
            };

            string[] part4 =
            {
                "apple-john", "baggage", "barnacle", "Basket-Cockle", "bladder", "blind-worm", "boar-pig", "bugbear", "bum-bailey", "canker-blossom", "clack-dish", "clotpole", "codpiece", "coxcomb", "death-token", "devil-monk", "dewberry", "flap-dragon", "flax-wench", "flirt-gill", "foot-licker", "fustilarian", "giglet", "gudgeon", "haggard", "harpy", "hedge-pig", "horn-beast", "hugger-mugger", "joithead", "jolt-head", "knave", "lewdster", "lout", "maggot-pie", "malcontent", "malt-worm", "mammet", "measle", "minnow", "miscreant", "moldwarp", "mumble-news", "nut-hook", "pigeon-egg", "pignut", "popinjay", "pumpion", "puttock", "rascal", "ratsbane", "scullian", "scut", "skainsmate", "strumpet", "toad", "varlot", "vassal", "wagtail", "whey-face"
            };

            return part1 + RandomSelect(part2) + " " + RandomSelect(part3) + " " + RandomSelect(part4) + "!";
        }

        #endregion Random comment

        #region Random (Latin & German) Text

        public static string RandomizeRandomText()
        {
            string[] randomText =
                {
                    "Pater noster, qui es in coelis, Sanctificetur Nomen tuum.", "Unser Vater, der Du bist im Himmel!",
                    "Geheiligt werde Dein Name.",
                    "Adveniat regnum tuum.", "Dein Reich komme.",
                    "Fiat voluntas tua, Sicut in coelo, et in terra.",
                    "Dein Wille geschehe, wie im Himmel, so auch auf Erden.",
                    "Panem nostrum quotidianum da nobis hodie.", "Gib uns heute unser tägliches Brot.",
                    "Et dimitte nobis debita nostra, Sicut et nos dimittimus debitoribus nostris.",
                    "Und vergib uns unsere Schulden, wie auch wir vergeben unseren Schuldern.",
                    "Et ne nos inducas in tentationem; Sed libera nos a malo.",
                    "Und führe uns nicht in Versuchung, sondern errette uns von dem Bösen.",
                    "Denn Dein ist das Reich und die Kraft und die Herrlichkeit in Ewigkeit!",
                    "Semper fi!", "Lobet den Herrn!", "Der Name des Herrn sei gelobt!", "Dominus vobiscum!",
                    "Der Herr sei mit euch!"
                };
            return RandomSelect(randomText);
        }

        #endregion Random (Latin & German) Text

        #region Divisions

        public static string RandomizeDivision()
        {
            string[] divisions =
                {
                    "Upper", "Lower"
                };
            return RandomSelect(divisions);
        }

        #endregion Divisions

        #region Gender

        public static string RandomizeGender()
        {
            string[] genders = { "M", "F" };
            return RandomSelect(genders);
        }

        public static string OppositeGender(string gender)
        {
            return gender == CommonStrings.gMale ? CommonStrings.gFemale : CommonStrings.gMale;
        }

        #endregion Gender

        #region Relation

        public static string ReturnRelation(string gender)
        {
            return gender == CommonStrings.gMale ? CommonStrings.rFather : CommonStrings.rMother;
        }

        public static string RandomizeRelation(string gender)
        {
            string[] fRelations = { "Mother", "Step-Mother", "Grandmother", "Guardian" };
            string[] mRelations = { "Father", "Step-Father", "Grandfather", "Guardian" };
            return (gender == CommonStrings.gMale) ? RandomSelect(mRelations).Trim() : RandomSelect(fRelations).Trim();
        }

        #endregion Relation

        #region Title

        public static string RandomizeTitleForGender(string gender)
        {
            return RandomSelect(gender == CommonStrings.gMale ? titlesM : titlesF);
        }

        #endregion Title

        #region Name

        public static string RandomizeFirstNameForGender(string gender)
        {
            return gender == CommonStrings.gMale ? RandomizeMaleFirstName() : RandomizeFemaleFirstName();
        }

        #endregion Name

        #region Occupation

        public static string RandomizeOccupation()
        {
            string[] occupations =
                {
                    "Accountant", "Actor", "Acupuncturist", "Agricultural Engineer", "Aircraft Mechanic", "Anesthesiologist", "Archaeologist", "Architect", "Archivist", "Attorney", "Automotive Mechanic",
                    "Baker", "Barrister", "Bartender", "Biochemist", "Biotechnologist", "Blacksmith", "Botanist", "Bricklayer", "Building Inspector", "Business Valuation Specialist", "Butcher",
                    "Cabinetmaker", "Camera Operator", "Cardiologist", "Carpenter", "Cartographer", "Chef", "Chemical Engineer", "Chemist", "Chiropractor", "Civil Engineer", "Clergy", "Code-Refactoring Genius", "Composer", "Construction Worker", "Copywriter", "Cotton Grower", "Customer Service Manager",
                    "Dairy Farmer", "Dancer", "Database Administrator", "Dental Hygienist", "Dentist", "Dermatologist", "Detective", "Dietician", "Director", "D.J.", "Diver", "Diving Instructor", "Dog Trainer", "Driving Instructor",
                    "Economist", "Educational Psychologist", "Electrical Engineer", "Electrician", "Emergency Medical Technician", "Endocrinologist", "Engraver",
                    "Facilities Manager", "Family and Marriage Counselor", "Film Director", "Financial Manager", "Fire Fighter", "Fitness Instructor", "Florist", "Forester", "Funeral Director",
                    "Gasfitter", "Gastroenterologist", "Geophysicist", "Goat Farmer", "Golfer", "Grape Grower", "Graphic Designer", "Greenkeeper", "Gunsmith", "Gymnast",
                    "Hairdresser", "Health Inspector", "Helicopter Pilot", "Historian", "Homeopath", "Horse Breeder", "Horse Trainer", "Hotel Manager", "Human Resource Manager", "Hydrologist",
                    "Illustrator", "Industrial Engineer", "Information Technologist", "Insurance Agent", "Insurance Broker", "Insurance Investigator", "Intelligence Officer", "Intensive Care Specialist", "Internal Auditor", "Interpreter",
                    "Jeweller", "Jewellery Designer", "Jockey", "Journalist", "Judge",
                    "Kennel Worker", "Kickboxer",
                    "Lab Manager", "Landscaper", "Librarian", "Library Technician", "Lighting Technician", "Locksmith",
                    "Magistrate", "Marine Biologist", "Massage Therapist", "Mathemetician", "Mechanical Engineer", "Metallurgist", "Meteorologist", "Microbiologist", "Midwife", "Motorcycle Mechanic", "Music Director", "Music Teacher",
                    "Naturopath", "Network Administrator", "Neurologist", "Neurosurgeon", "Nuclear Physicist", "Nurse Practitioner", "Nutritionist",
                    "Obstetrician", "Occupational Therapist", "Office Manager", "Opthalmologist", "Optometrist", "Osteopath",
                    "Painter", "Park Ranger", "Pathologist", "Pediatrician", "Photographer", "Physicist", "Physiotherapist", "Plumber", "Podiatrist", "Politician", "Postal Worker", "Poultry Farmer", "Printer", "Production Manager", "Psychiatrist", "Psychologist",
                    "Quality Assurance Manager",
                    "Radiologist", "Real Estate Agent", "Records Manager", "Registered Nurse", "Rehabilitation Specialist", "Research Specialist", "Retail Manager", "Rheumatologist", "Roofer",
                    "Safety Inspector", "Sail Maker", "Sales and Marketing Manager", "Sales Representative", "School Principal", "School Teacher", "Sculptor", "Sheep Farmer", "Shepherd", "Shipwright", "Ship Worker", "Shoemaker", "Signwriter", "Singer", "Social Worker", "Software Engineer", "Soil Inspector", "Sound Technician", "Statistician", "Structural Engineer", "Surgeon", "Surveyor", "Swimming Instructor", "Systems Administrator", "Systems Analyst",
                    "Tailor", "Tax Accountant", "Technical Writer", "Telecommunications Technician", "Textile Engineer", "Toolmaker", "Translator", "Travel Agent",
                    "University Lecturer", "Upholsterer", "Urban and Regional Planner", "Urologist",
                    "Vascular Surgeon", "Vegetable Grower", "Veterinarian", "Video Producer",
                    "Watchmaker", "Web Designer", "Welder", "Wine Maker",
                    "Youth Worker",
                    "Zookeeper", "Zoologist"
                };
            return RandomSelect(occupations);
        }

        #endregion Occupation

        #region Ideas for a database-driven implementation

        //public string FirstNameSelect()
        //{
        //    using (var ctx = new ef.ThinkTankTestPrepEntities())
        //    {
        //        var fn = ctx.Registrants.Select(r => r.FirstName).ToArray();
        //        return RandomSelect(fn);
        //    }
        //}

        //public string LastNameSelect()
        //{
        //    using (var ctx = new ef.ThinkTankTestPrepEntities())
        //    {
        //        var ln = ctx.Registrants.Select(r => r.LastName).ToArray();
        //        return RandomSelect(ln);
        //    }
        //}

        #endregion Ideas for a database-driven implementation
    }


    #region CryptoRandom Class

    /// <summary>
    /// Slightly modified cryptorandom class - was missing random generation of Longs. Don't remember where the original source is, so use "the Google" to find it.
    /// </summary>
    internal class CryptoRandom : Random
    {
        private readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        private readonly byte[] _uint32Buffer = new byte[4]; //  new byte[sizeof(uint)]
        private readonly byte[] _ulongBuffer = new byte[sizeof(long)]; // added this as it was needed
        public CryptoRandom() { }
        public CryptoRandom(Int32 ignoredSeed) { }
        public override Int32 Next()
        {
            _rng.GetBytes(_uint32Buffer);
            return BitConverter.ToInt32(_uint32Buffer, 0) & 0x7FFFFFFF;
        }

        public override Int32 Next(Int32 maxValue)
        {
            if (maxValue < 0)
                throw new ArgumentOutOfRangeException("maxValue");
            return Next(0, maxValue);
        }

        public long NextLong(long minValue, long maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;
            long diff = maxValue - minValue;
            while (true)
            {
                _rng.GetBytes(_ulongBuffer);
                var rand = BitConverter.ToInt64(_ulongBuffer, 0);
                const long max = (long.MaxValue);
                var remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (minValue + (rand % diff));
                }
            }
        }

        public override int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;
            var diff = maxValue - minValue;
            while (true)
            {
                _rng.GetBytes(_uint32Buffer);
                var rand = BitConverter.ToUInt32(_uint32Buffer, 0);
                const long max = (1 + (long)uint.MaxValue);
                var remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (int)(minValue + (rand % diff));
                }
            }
        }

        public override double NextDouble()
        {
            _rng.GetBytes(_uint32Buffer);
            UInt32 rand = BitConverter.ToUInt32(_uint32Buffer, 0);
            return rand / (1.0 + UInt32.MaxValue);
        }

        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer");
            _rng.GetBytes(buffer);
        }
    }


    ///<summary>
    /// Represents a pseudo-random number generator, a device that produces random data.
    ///</summary>
    internal class MyCryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator _r;

        ///<summary>
        /// Creates an instance of the default implementation of a cryptographic random number generator that can be used to generate random data.
        ///</summary>
        public MyCryptoRandom()
        {
            _r = Create();
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        public override void GetBytes(byte[] buffer)
        {
            _r.GetBytes(buffer);
        }

        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public double NextDouble()
        {
            var b = new byte[4];
            _r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        /// <summary>
        /// Returns a random number within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns></returns>
        public int Next(int minValue, int maxValue)
        {
            var val = (int)Math.Floor(NextDouble() * (maxValue - (minValue - 1)) + minValue);
            return val < maxValue ? val : Next(minValue, maxValue);
        }

        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }

        /// <summary>
        /// Returns a nonnegative random number less than the specified maximum
        /// </summary>
        /// <param name="maxValue">The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        /// <returns></returns>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }

    #endregion CryptoRandom Class
}
