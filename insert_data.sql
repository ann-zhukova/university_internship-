insert into Department (name) 
values ('Разработка 1'), 
       ('Развертывание'), 
	   ('Тестирование'), 
       ('Аналитика'), 
	   ('Сопровождение'), 
       ('Управление данными'), 
	   ('Работа с клиентами'), 
       ('Техподдержка'), 
	   ('Разработка 2'), 
       ('Разработка 3');
insert into Salary (salary)
values  (100.0),
		(120.0),
		(140.4),
		(135.6),
		(147.5),
		(182.3),
		(111.1),
		(178.8),
		(100.0),
		(185.5);
insert into WorkerPosition (name, salary)
values 	('Младший инженер программист', 1),
		('Средний инженер программист', 2),
		('Инженер по нагрузочному тестированию', 3),
		('Младший Аналитик', 4),
		('Старший Аналитик', 5),
		('Старший инженер программист', 6),
		('QA инженер', 7),
		('DevOp инженер', 8),
		('Специалист техподдержки', 9),
		('Инженер по сопровождению', 10);
insert into Worker (name, position, department)
values  ('Иванов Иван', 6, 1), 
		('Петров Петр', 2, 10),
		('Васечкин Василий', 10, 5),
		('Ильин Илья', 10, 5),
		('Вавилов Петр', 1, 1),
		('Ломоносов Михаил', 1, 9),
		('Колев Николай', 3, 3),
		('Гагарин Юрий', 8, 2),
		('Титов Герман', 5, 6),
		('Иванушкин Петр', 5, 4),
		('Владимиов Владимир', 7, 3),
		('Вячеславов Вячеслав', 9, 8),
		('Складовская Мария', 6, 1),
		('Лавлейс Ада', 2, 1);
insert into Project (name, status)
values  ('Сайт ботонического сада', false), 
		('Сайт аэрокосмического университета', false), 
		('Мониторинг сайта приюта для животных', false), 
		('Автоматизированная система аналитики', false), 
		('Сайт продажи носков', false), 
		('Сайт продажи цветов', false), 
		('Сайт аренды сельскохозяйственной техники', false), 
		('Сайт аренды квартир и комнат', false), 
		('Сайт онлайн курсов по программированию', false),
		('Мониторинг сайта разработки видеоигр', false);
		
insert into Task (name, description, start_date, end_date, status, dependsOnTask, project)
values  ('Разработка сайта ботанического сада', 'Разработка', '2024-07-01', '2024-09-01', false, NULL, 1),
		('Разработка сайта аэрокосмического университета', 'Разработка', '2024-07-01', '2024-08-01', false, NULL, 2),
		('Тестирование сайта ботанического сада', 'Unit тестирование, нагрузочное тестирование', '2024-08-01', '2024-10-01', false, 1, 1),
		('Разработка автоматизированной системы аналитики', 'Разработка и тестирование системы', '2024-07-01', '2024-12-01', false, NULL, 4),
		('Сопровождение сайта ботанического сада', 'Мониторинг оповещений, решение инцидентов', '2024-10-01', '2025-12-01', false, 3, 1),
		('Развертывание сайта ботонического сада', 'Настройка окружения и развертывание сайта', '2024-09-01', '2024-10-01', false, 5, 1),
		('Обновление сайта приюта для животных', 'Обновление и тестирование сайта', '2024-12-01', '2025-01-01', false, NULL, 3),
		('Обновление автоматизированной системы аналитики', 'Обновление и тестирование системы', '2024-12-01', '2025-01-01', false, NULL, 4),
		('Обновление сайта продажи носков', 'Обновление и тестирование сайта', '2024-12-01', '2025-01-01', false, NULL, 5),
		('Обновление сайта продажи цветов', 'Обновление и тестирование сайта', '2024-12-01', '2025-01-01', false, NULL, 6),
		('Обновление сайта аренды сельскохозяйственной техники', 'Обновление и тестирование сайта','2024-12-01', '2025-01-01', false, NULL, 7);
insert into WorkerDoTask (worker, task)
values  (1,1),
		(1,2),
		(7,3),
		(11,3),
		(14,2),
		(9,2),
		(3,5),
		(3,6),
		(8,6),
		(5,1),
		(1,3),
		(9,4),
		(10,4);
