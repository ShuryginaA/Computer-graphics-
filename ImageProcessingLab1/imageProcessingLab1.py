# -*- coding: utf-8 -*-
import numpy as np
import matplotlib as mp

###Зарплаты(указаны после 30% налога с работодателя, до вычета 13% налога)
##Зарплаты указаны за час работы, то есть для того чтобы узнать з/п за месяц 
##требуется умножить на 8 рабочих часов и на 22 рабочих дня(X*8*22)(для удобства подсчета)
########Все зарплаты учителям добавлены в СЛОВАРЬ(dictionary) 
########структура данных в питоне пара ключ значение(map java)
teacherSalaries={
#История
'historyTeacher':171,
#Философия
'philosophyTeacher':171,
#Экономика
'economyTeacher':180,
#Иностранный язык
'englishTeacher':185,
#Высшая математика
'higherMathTeacher':285,
#Дискретная математика
'discretMathTeacher':260,
#Математическая логика и теория алгоритмов
'mathAndAlgorithmTheoryTeacher':340,
#Теория автоматов и формальных языков
'automataTheoryTeacher':260,
#Теория вероятностей и математическая статистика
'probabilitiesTheoryAndMathStatisticsTeacher':228,
#Информатика и программирование
'computerScienceAndProgrammmingTeacher':285,
#Архитектура вычислительных систем
'computingSystemsArchitectureTeacher':228,
#Операционные системы
'operatingSystemsTeacher':250,
#Технологии баз данных
'dataBaseTehnologyTeacher':228,
#Экономика программной инженерии
'programEngineeringEconomyTeacher':180,
#Физическая культура и спорт
'physicalEducationTeacher':150,
#Безопасность жизнедеятельности
'lifeSafetyTeacher':150,
#Правоведение
'jurisprudenceTeacher':155,
#Социально-этические вопросы информационных технологий
'socioEthicalIssuesOfInformationTechnologyTeacher':171,
#Физика
'phisicsTeacher':228,
#Основы безопасности информационных технологий
'fundamentalsOfInformationTechnologySecurityTeacher':228,
#Методы оптимизации
'optimizationMethodsTeacher':185,
#Исследование операций
'operationsResearchTeacher':228,
#Компьютерные сети
'computerNetworkTeacher':228,
#Численные методы
'numericalMethodsTeacher':185,
#Введение в проектную деятельность
'enteringProjectWorkingTeacher':171,
##Часть, формируемая участниками образовательных отношений(вариативные дисциплины)
#Теория систем и системный анализ
'systemTheoryAndAnalitycsTeacher':228,
#Технологии визуального программирования
'visualTechnologyProgrammingTeacher':228,
#Java
'javaTeacher':285,
#Параллельное программирование
'parallelProgrammingTeacher':285,
#Технологии сети Интернет
'InternetTechnologyTeacher':228,
#Разработка и анализ требований
'developmentAndAnalitycsRequarementsTeacher':185,
#Программирование роботов
'robotProrammingTeacher':228,
#Тестирование программного обеспечения
'softwareTestingTeacher':228,
#Управление программными проектами
'programProductManagementTeacher':228,
#Технология распределённой обработки
'technologyOfDistributedProcessingTeacher':185,
#Конструирование программного обеспечения
'constructionOfSoftwareTeacher':285,
#Проектирование и архитектура программных систем
'designingAndArchitectureOfSoftwareSystemsTeacher':285,
#Алгоритмы и структуры данных
'algorithmsAndDataStructureTeacher':285,
#Инструменты программирования
'programmingToolsTeacher':228,
#Компьютерная графика
'computerGraphicsTeacher':228,
#Проектирование человеко-машинного интерфейса
'designingHumanMachineInterfaceTEacher':185,
#Системы компьютерной математики
'computerMathSystemTeacher':285,
#Введение в Интернет вещей
"introductionToTheInternetOfThingsTeacher":228,
#Документирование программного обеспечения
'documetationOfSoftwareTeacher':185,
#Технологии Интернета вещей
'theInternetOfThingsTeacher':185,
#Управление системами телекоммуникаций
'managementOfTelecommunicationSystemsTeacher':228,
#Обработка изображений
'imageProcessingTeacher':228,
#Программирование на новых архитектурах
'newArchitectProgrammingTeacher':228,
#Основы компьютерного зрения
'basicsOfComputerVisionTeacher':285,
#Облачные вычисления
'cloudCalculationsTeacher':285,
#Разработка сетевых приложений (Java)
'developmentOfNetworkApplicationsTeacher':285,
#Проектная деятельность в сфере программной инженерии
'projectActivityInTheFieldOfSoftwareEngineeringTeacher':285,
#
##Дисциплины по выбору
#Наглядный вероятностно-статистический анализ данных
'visualProbabilisticAndStatisticalDataAnalysisTeacher':228,
#Теория выбора и принятия решений
'theoryOfChoiceAndDecisionMakingTeacher':228,
#Программирование мобильных систем
'programmingOfMobileSystemsTeacher':228,
#Системы поддержки принятия решений
'decisionSupportSystemsTeacher':228
}
###Студенты в группах
groupType1=12
groupType2=22

###Количество пар в неделю 1 преподавателя(полная и пол ставки)
lessonsPerTeacher1=5
lessonsPerTeacher2=10

###Свой тип данных для обозначения предметов
###(название/часы за все семестры/количество семестров)
class subjectByHoursAndSemesters:
    def __init__(self, subject, hours,semester):
        self.subject=subject
        self.hours=hours
        self.semester=semester
 
    def getSubject(self):
        return self.subject
    def getHours(self):
        return self.hours
    def getSemester(self):
        return self.semester
###Разбиение предметов по часам и семестрам
##Обязательные дисциплины
#История
history=subjectByHoursAndSemesters('history',
                                   108, [1])
#Философия
philosophy=subjectByHoursAndSemesters('philosophy',
                                      144, [2])
#Экономика
economy=subjectByHoursAndSemesters('economy',
                                   72, [1])
#Иностранный язык
english=subjectByHoursAndSemesters('english',
                                   252, [1,2,3])
#Высшая математика
higherMath=subjectByHoursAndSemesters('higherMath',
                                      540, [1,2,3])
#Дискретная математика
discretMath=subjectByHoursAndSemesters('discretMath',
                                       324, [1,2])
#Математическая логика и теория алгоритмов
mathAndAlgorithmTheory=subjectByHoursAndSemesters('mathAndAlgorithmTheory',
                                                  144, [3])
#Теория автоматов и формальных языков
automataTheory=subjectByHoursAndSemesters('automataTheory', 108, [7])
#Теория вероятностей и математическая статистика
probabilitiesTheoryAndMathStatistics=subjectByHoursAndSemesters('probabilitiesTheoryAndMathStatistics',
                                                                288, [5,6])
#Информатика и программирование
computerScienceAndProgrammming=subjectByHoursAndSemesters('computerScienceAndProgrammming',
                                                          432, [1,2])
#Архитектура вычислительных систем
computingSystemsArchitecture=subjectByHoursAndSemesters('computingSystemsArchitecture',
                                                        144, [3])
#Операционные системы
operatingSystems=subjectByHoursAndSemesters('operatingSystems',
                                            180, [4])
#Технологии баз данных
dataBaseTehnology=subjectByHoursAndSemesters('dataBaseTehnology',
                                             144, [4])
#Экономика программной инженерии
programEngineeringEconomy=subjectByHoursAndSemesters('programEngineeringEconomy',
                                                     108, [7,8])
#Физическая культура и спорт
physicalEducation=subjectByHoursAndSemesters('physicalEducation',
                                             72, [1,2])
#Безопасность жизнедеятельности
lifeSafety=subjectByHoursAndSemesters('lifeSafety', 72, [7])
#Правоведение
jurisprudence=subjectByHoursAndSemesters('jurisprudence',72, [7])
#Социально-этические вопросы информационных технологий
socioEthicalIssuesOfInformationTechnology=subjectByHoursAndSemesters('socioEthicalIssuesOfInformationTechnology',
                                                                     108, [7])
#Физика
phisics=subjectByHoursAndSemesters('phisics', 108, [6])
#Основы безопасности информационных технологий
fundamentalsOfInformationTechnologySecurity=subjectByHoursAndSemesters('fundamentalsOfInformationTechnologySecurity',
                                                                       72, [8])
#Методы оптимизации
optimizationMethods=subjectByHoursAndSemesters('optimizationMethods',
                                               252, [4,5])
#Исследование операций
operationsResearch=subjectByHoursAndSemesters('operationsResearch',
                                              144, [8])
#Компьютерные сети
computerNetwork=subjectByHoursAndSemesters('computerNetwork', 108, [5])
#Численные методы
numericalMethods=subjectByHoursAndSemesters('numericalMethods', 144, [5])
#Введение в проектную деятельность
enteringProjectWorking=subjectByHoursAndSemesters('enteringProjectWorking',
                                                  72, [1])
##Часть, формируемая участниками образовательных отношений(вариативные дисциплины)
#Теория систем и системный анализ
systemTheoryAndAnalitycs=subjectByHoursAndSemesters('systemTheoryAndAnalitycs', 
                                                    108, [8])
#Технологии визуального программирования
visualTechnologyProgramming=subjectByHoursAndSemesters('visualTechnologyProgramming',
                                                       108,[2])
#Java
java=subjectByHoursAndSemesters('java',108, [3])
#Параллельное программирование
parallelProgramming=subjectByHoursAndSemesters('parallelProgramming',180,[5,6])
#Технологии сети Интернет
internetTechnology=subjectByHoursAndSemesters('InternetTechnology',72,[5])
#Разработка и анализ требований
developmentAndAnalitycsRequarements=subjectByHoursAndSemesters('developmentAndAnalitycsRequarements',
                                                               72,[5])
#Программирование роботов
robotProramming=subjectByHoursAndSemesters('robotProramming',108, [1])
#Тестирование программного обеспечения
softwareTesting=subjectByHoursAndSemesters('softwareTesting',72, [6])
#Управление программными проектами
programProductManagement=subjectByHoursAndSemesters('programProductManagement',
                                                    108,[7])
#Технология распределённой обработки
technologyOfDistributedProcessing=subjectByHoursAndSemesters('technologyOfDistributedProcessing', 
                                                             72,[8])
#Конструирование программного обеспечения
constructionOfSoftware=subjectByHoursAndSemesters('constructionOfSoftware',144, [4])
#Проектирование и архитектура программных систем
designingAndArchitectureOfSoftwareSystems=subjectByHoursAndSemesters('designingAndArchitectureOfSoftwareSystems',
                                                                     108, [7])
#Алгоритмы и структуры данных
algorithmsAndDataStructure=subjectByHoursAndSemesters('algorithmsAndDataStructure',
                                                      468,[3,4])
#Инструменты программирования
programmingTools=subjectByHoursAndSemesters('programmingTools',72, [6])
#Компьютерная графика
computerGraphics=subjectByHoursAndSemesters('computerGraphics', 144,[4])
#Проектирование человеко-машинного интерфейса
designingHumanMachineInterface=subjectByHoursAndSemesters('designingHumanMachineInterface', 
                                                          108, [2])
#Системы компьютерной математики
computerMathSystem=subjectByHoursAndSemesters('computerMathSystem',72, [2])
#Введение в Интернет вещей
introductionToTheInternetOfThings=subjectByHoursAndSemesters('introductionToTheInternetOfThings',
                                                             72, [3])
#Документирование программного обеспечения
documetationOfSoftware=subjectByHoursAndSemesters('documetationOfSoftware',144,[3])
#Технологии Интернета вещей
theInternetOfThings=subjectByHoursAndSemesters('theInternetOfThings',72,[4])
#Управление системами телекоммуникаций
managementOfTelecommunicationSystems=subjectByHoursAndSemesters('managementOfTelecommunicationSystems', 
                                                                72, [5])
#Обработка изображений
imageProcessing=subjectByHoursAndSemesters('imageProcessing',
                                           72, [5])
#Программирование на новых архитектурах
newArchitectProgramming=subjectByHoursAndSemesters('newArchitectProgramming',108, [7])
#Основы компьютерного зрения
basicsOfComputerVision=subjectByHoursAndSemesters('basicsOfComputerVision',108,[7])
#Облачные вычисления
cloudCalculations=subjectByHoursAndSemesters('cloudCalculations',72, [8])
#Разработка сетевых приложений (Java)
developmentOfNetworkApplications=subjectByHoursAndSemesters('developmentOfNetworkApplications',
                                                            72, [6])
#Проектная деятельность в сфере программной инженерии
projectActivityInTheFieldOfSoftwareEngineering=subjectByHoursAndSemesters('projectActivityInTheFieldOfSoftwareEngineering',
                                                                          72, [6])
#
##Дисциплины по выбору
#Наглядный вероятностно-статистический анализ данных
visualProbabilisticAndStatisticalDataAnalysis=subjectByHoursAndSemesters
('visualProbabilisticAndStatisticalDataAnalysis',108,[8])
#Теория выбора и принятия решений
theoryOfChoiceAndDecisionMaking=subjectByHoursAndSemesters('theoryOfChoiceAndDecisionMaking',
                                                           108, [8])
#Программирование мобильных систем
programmingOfMobileSystems=subjectByHoursAndSemesters('programmingOfMobileSystems',72, [6])
#Системы поддержки принятия решений
decisionSupportSystems=subjectByHoursAndSemesters('decisionSupportSystems',72, [6])
#Теперь все эти данные о предметах попадают в коллаж
subjectByHoursAndSemesterslist=[history,philosophy,economy,designingAndArchitectureOfSoftwareSystems,
                                english,higherMath,discretMath,mathAndAlgorithmTheory,automataTheory,
                                probabilitiesTheoryAndMathStatistics,computerScienceAndProgrammming,
                                computingSystemsArchitecture,operatingSystems,dataBaseTehnology,
                                programEngineeringEconomy,physicalEducation,lifeSafety,jurisprudence,
                                socioEthicalIssuesOfInformationTechnology,phisics,
                                fundamentalsOfInformationTechnologySecurity,optimizationMethods,
                                operationsResearch,computerNetwork,numericalMethods,
                                enteringProjectWorking,systemTheoryAndAnalitycs,visualTechnologyProgramming,
                                java,parallelProgramming,internetTechnology,developmentAndAnalitycsRequarements,
                                robotProramming,softwareTesting,programProductManagement,
                                technologyOfDistributedProcessing,constructionOfSoftware,
                                designingAndArchitectureOfSoftwareSystems,algorithmsAndDataStructure,
                                programmingTools,computerGraphics,designingHumanMachineInterface,
                                computerMathSystem,introductionToTheInternetOfThings,
                                documetationOfSoftware,theInternetOfThings,managementOfTelecommunicationSystems,
                                imageProcessing,newArchitectProgramming,basicsOfComputerVision,
                                cloudCalculations,developmentOfNetworkApplications,
                                projectActivityInTheFieldOfSoftwareEngineering]
###Плата за аренду(м^2) в рублях
rentMeter=500
###Плата за коммунальные услуги(м^2) в рублях
utilites=100
#

#
##
