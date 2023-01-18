List<IPerson> people = new List<IPerson>();

add teacher... add student... add worker... etc... (all implemented from IPerson)

foreach(var p in people)
	{
		if (p is Teacher teacher) // => if he is of type Teacher, name him "teacher"
			{
				teacher.GetSalary();  // => now we have access to GetSalary(); which is exclusive to teachers
			}
	}
