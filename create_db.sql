create table Department (
	id serial primary key, 
	name varchar(50)
);
create table Salary (
	id serial primary key,
	salary decimal
); 
create table WorkerPosition (
	id serial primary key, 
	name varchar(100),
	salary integer unique, 
	foreign key (salary) references Salary(id)
);

create table Worker (
	id serial primary key, 
	name varchar(50),
	position integer,
	foreign key (position) references WorkerPosition(id),
	department integer,
	foreign key (department) references Department(id)
);

create table Project (
	id serial primary key, 
	name varchar(50), 
	status boolean
);

create table Task (
    id serial primary key,
    name varchar(100),
    description text,
    start_date date,
    end_date date,
	status bool, 
	dependsOnTask integer, 
	foreign key (dependsOnTask) references Task(id),
	project integer, 
	foreign key (project) references Project(id)
);

create table WorkerDoTask(
	worker integer,
   	foreign key (worker) references Worker(id),
	task integer, 
	foreign key (task) references Task(id), 
	PRIMARY KEY (worker, task)
);


