--аудит событий 
CREATE OR REPLACE FUNCTION worker_audit_trigger()
RETURNS TRIGGER AS $$
BEGIN
    IF (TG_OP = 'INSERT') THEN
        INSERT INTO worker_audit (employee_id, action, action_timestamp)
        VALUES (NEW.employee_id, 'INSERT', current_timestamp);
        RETURN NEW;
    ELSIF (TG_OP = 'UPDATE') THEN
        INSERT INTO worker_audit (employee_id, action, action_timestamp)
        VALUES (NEW.employee_id, 'UPDATE', current_timestamp);
        RETURN NEW;
    ELSIF (TG_OP = 'DELETE') THEN
        INSERT INTO worker_audit (employee_id, action, action_timestamp)
        VALUES (OLD.employee_id, 'DELETE', current_timestamp);
        RETURN OLD;
    END IF;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER worker_audit
AFTER INSERT OR UPDATE OR DELETE ON worker
FOR EACH ROW
EXECUTE FUNCTION worker_audit_trigger();

-- проверка целостности данных
CREATE OR REPLACE FUNCTION check_start_date()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.start_date < (SELECT end_date FROM Task WHERE id = NEW.dependsOnTask) THEN
        RAISE EXCEPTION 'Дата начала не может быть раньше, чем зависимая задача';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER start_date_check
BEFORE INSERT OR UPDATE ON Task
FOR EACH ROW
EXECUTE FUNCTION check_start_date();

insert into Task (name, description, start_date, end_date, status, dependsontask, project)
values ('Тестирование сайта аэрокоса','', '2023-12-03', '2024-12-05',false, 2, 2);