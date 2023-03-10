#### What is the point of an aggregate?

It operates to a large degree as one thing. 
The Aggregate Root is the single entity that controls access to the children.

Aggregates provide a clean pattern to keep logic where it really belongs

Aggregate Root can be dealt with by a repository.

#### Restrictions on aggregates and aggregate roots


DDD is really just “OO software done right”


# code review
catch bugs
catch code quality issues
a learning opportunity
an exchange of best practices and experiences
a chance to synchronize

lead to better sw
win-win

dark side
amplifier: the good, the bad
  healthy culture

if the culture is not healthy, code review never pays off

#zdtip cron expression
ITrigger trigger = TriggerBuilder.Create()
       .WithCronSchedule("0 0 8 ? * MON-FRI *")
       .Build();

### this works, every 5 seconds
"HelloWorldJob": "0/5 * * * * ?"
### this works, at 7pm every weekday
"HelloWorldJob": "0 0 19 ? * MON-FRI *"
### this works, at 7:15pm every weekday
"HelloWorldJob": "0 15 19 ? * MON-FRI *"


### This should fire every day at 8am except for weekend
var trigger = TriggerBuilder
                 .Create()
                 .WithSchedule(CronScheduleBuilder
                                  .AtHourAndMinuteOnGivenDaysOfWeek(8,
                                                                    0,
                                                                    DayOfWeek.Monday,
                                                                    DayOfWeek.Tuesday,
                                                                    DayOfWeek.Wednesday,
                                                                    DayOfWeek.Thursday,
                                                                    DayOfWeek.Friday))
                 .Build();

### Conversation with a Domain Expert: Exploring the Scheduling Subdomain
### Conversation with a Domain Expert: Exploring the Scheduling Subdomain

Now that we have a better understanding of the domain and the other subdomains around the scheduling system, it's time to focus more on understanding the scheduling subdomain. We had another meeting with Dr. Smith, and you can listen in. ‑Hi guys, welcome back to the clinic. How are things going with the computer system? ‑We're making good progress, and now we're ready to look at another more complex feature. ‑We know there's a lot that goes on here, but today we want to focus on appointment scheduling because we realize we're still a little confused about it. ‑Since we've both owned pets for a long time, we figure we probably have a rough idea of what's needed, but it'll be good to talk through it with you. Do your patients usually schedule their appointments over the phone? ‑Okay, so yeah our patients aren't usually involved in the scheduling. Usually, it's the clients that call in for appointments for their pets. And yeah, usually it's on the phone or in person when they're checking out after an office visit. Julie and I talked about that earlier. ‑Yeah, so Steve, the patients are the animals, and the clients are the people or the pet owners. ‑Right, right, of course, that'll be important to get right. ‑Remember, we talked about that. So the client needs to make an appointment for their pet. They'll talk to a staff member who will schedule the appointment. What kind of information do they need in order to do that? ‑So that really depends on the type of appointment. It could be an office visit, or it could be a surgery. Why don't we talk about the office visits first. If it's just for a wellness exam, that's pretty standard. They just need to choose an available time slot with one of the doctors. Some of the visits can be scheduled with just a technician though, so if they need just their toenails trimmed, for example. ‑Or painted, like Samson. He gets his toenails painted. ‑Does he really? ‑No, I'm joking. I just want to, pink. ‑I'm sure he'd love that. Okay, so office visits might be an exam requiring the doctor or another kind of appointment that only requires a technician. ‑Right. We also have to worry about our rooms too. We only have five exam rooms available, and we try not to overbook. We don't like for our clients to have to wait too long in the reception area, especially if we have a lot of cats and big dogs out there at the same time. It makes them all really nervous. ‑What about other staff? ‑So our technicians will float between the exam rooms and other areas of the clinic as needed, except, of course, for those scheduled technician visits. We do have a schedule for the staff, but it's separate from how we schedule our appointments. ‑Okay, so what about the surgeries? ‑Well, if it's a surgery, those are only scheduled on certain days, and they require that the operating room be available, as well as some recovery space in the kennel area. It also depends on what kind of surgery or procedure we're going to be doing. Something simple like a dental cleaning takes less time and fewer people than a caesarean section for a bulldog. ‑Okay, so an appointment is either an office visit or a surgery. Office visits happen in the exam room; surgeries require the operating room and recovery space. Is that right? ‑Right. And depending on the reason for the visit or the surgery, different staff might need to be involved. ‑So we'll probably want to have separate classes for appointments and surgeries. ‑Classes? No, we refer our clients to obedience and puppy preschool classes at other facilities. We don't actually schedule any of those in the clinic themselves. ‑I'm sorry. That's a software term. In software, we have different classifications of concepts in the program, which are called classes. I'm just getting ahead of myself here. Sorry. ‑Don't worry. We're not going to make you learn our software terms. Steve and I will try to have a little bit more self control with that. We do want to make sure we're all speaking the same language when it comes to concepts in the application though. ‑Okay, so I have another quick question. Do we have to worry about multiple staff members scheduling appointments at the same time? ‑No, there should only ever be one person doing the scheduling at a time, although I could see if we grew in the future that could change. But I don't think that'll happen in the next couple of years. Okay, then we don't have to worry about the rare occurrence of two people creating a conflict if they're trying to schedule an appointment for different patients in the same room or with the same doctor. That'll keep things a lot simpler. And we need to know before an appointment if certain resources are available, like rooms and doctors. And then if they are and we want to schedule the appointment, then we need to be able to book the doctor, the room, and any other resources. Hey, is it okay if we refer to doctors as resources? ‑Sure, that makes sense. You know, I think it makes sense to use the term resources to refer to the doctors, the rooms, and the technicians since those are all things that can affect whether or not an appointment can be scheduled. But remember, sometimes it'll be just a vet tech in a room, and other times it might be the doctor in the room, but sometimes you might need the doctor, the technician, and a room. ‑Wow, this is a lot more complicated than we'd realized, but it's interesting. This is going to be cool to model in the application.

So we'll probably want to have separate classes for appointments and surgeries. 
‑Classes? No, we refer our clients to obedience and puppy preschool classes at other facilities. We don't actually schedule any of those in the clinic themselves. ‑I'm sorry. That's a software term. In software, we have different classifications of concepts in the program, which are called classes. I'm just getting ahead of myself here. Sorry. 
‑Don't worry. We're not going to make you learn our software terms. Steve and I will try to have a little bit more self control with that. We do want to make sure we're all speaking the same language when it comes to concepts in the application though. 


‑Okay, so I have another quick question. Do we have to worry about multiple staff members scheduling appointments at the same time? ‑No, there should only ever be one person doing the scheduling at a time, although I could see if we grew in the future that could change. But I don't think that'll happen in the next couple of years. Okay, then we don't have to worry about the rare occurrence of two people creating a conflict if they're trying to schedule an appointment for different patients in the same room or with the same doctor. That'll keep things a lot simpler. And we need to know before an appointment if certain resources are available, like rooms and doctors. And then if they are and we want to schedule the appointment, then we need to be able to book the doctor, the room, and any other resources. Hey, is it okay if we refer to doctors as resources? ‑Sure, that makes sense. You know, I think it makes sense to use the term resources to refer to the doctors, the rooms, and the technicians since those are all things that can affect whether or not an appointment can be scheduled. But remember, sometimes it'll be just a vet tech in a room, and other times it might be the doctor in the room, but sometimes you might need the doctor, the technician, and a room. ‑Wow, this is a lot more complicated than we'd realized, but it's interesting. This is going to be cool to model in the application.