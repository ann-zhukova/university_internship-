CREATE OR REPLACE FUNCTION replace_substring_in_name(old_substring TEXT, new_substring TEXT, worker_id INT) 
RETURNS VOID AS $$
BEGIN
    UPDATE worker
    SET name = REPLACE(name, old_substring, new_substring)
    WHERE id = worker_id;
END;
$$ LANGUAGE plpgsql; 
SELECT replace_substring_in_name('Виталий', 'Иван', 1);
select * from worker;

create or replace procedure get_project_tasks(in project_id int)
language plpgsql
as $$
declare
    task_record record;
begin
    for task_record in
        select name
        from task
        where project = project_id
        order by start_date
    loop
        raise notice 'Следующая задача: %', task_record.name;
    end loop;
end;
$$;
call get_project_tasks(1);