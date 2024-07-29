-- возвращает данные о сотрудниках подразделений и их должностях
with worker_data as (select worker.name as worker_name, WorkerPosition.name as position, department.name as department  
	from worker 
	left join department on worker.department = department.id 
	join WorkerPosition on worker.position = WorkerPosition.id 
	order by worker_name)
select * from worker_data;

-- возвращает информацию о сотрудниках назначенных на задачи
select  worker.name as worker_name, WorkerPosition.name as position, Task.name as Task  
	from WorkerDoTask 
	join worker on worker.id = WorkerDoTask.worker
	join WorkerPosition on worker.position = WorkerPosition.id 
	join Task on WorkerDoTask.task = Task.id;
	
-- возвращает время запланированной работы с проектом и количество назначенных задач
select project.id, project.name, sum(age(task.end_date, task.start_date)) as total_work_time, count(*) as total_task_count,
	avg(age(task.end_date, task.start_date)) as avg_task_time,
	min(age(task.end_date, task.start_date)) as max_task_time,
	max(age(task.end_date, task.start_date)) as max_task_time
	from task 
	join project on  project.id = task.project 
	group by project.id 
	order by  total_work_time desc;

-- возвращает все задачи и их иерархию
with recursive TaskHierarchy as (
    select id, concat(name, ':', lower(description)) as name, dependsonTask, 1 as level
    from Task
    where dependsonTask is null

    union all

    select t.id, concat(t.name,':', lower(t.description)) as name, t.dependsonTask, th.level + 1
    from Task t
    join TaskHierarchy th on t.dependsonTask = th.id
)
select id, name, dependsonTask, level
	from TaskHierarchy;
	
-- возвращает все задачи сотрудника 'Иванова Ивана'
select 'Иванов Иван' as Worker, task.name as task_name, task.description as task_description
from task join WorkerDoTask on task.id = WorkerDoTask.task
where WorkerDoTask.worker = (select worker.id from Worker where name = 'Иванов Иван');

--проекты которые нужно завершить в этом году
select distinct project.id, project.name from project join task on task.project = project.id 
where extract(year from task.end_date)=extract(year from current_date);

--данные о сотрудниках подразделений разработки
with worker_data as (select worker.name as worker_name, WorkerPosition.name as position, department.name as department  
	from worker 
	left join department on worker.department = department.id 
	join WorkerPosition on worker.position = WorkerPosition.id )

select * from worker_data where position('РАЗРАБОТКА' in upper(worker_data.department))>0;

--
update worker set name = replace(name, 'Виталий', 'Иван') where worker.id=1;
