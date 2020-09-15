# Zenkoban Developer Diary
## September 15th, 2020

I have spent some time today creating tasks for the work I have recently done / Have to do. I need to be more diligent in having tasks available to work on, rather than working on random things. This project is big, and I don't have a lot of time. If I don't want it to take forever, then I should maximise efficiency wherever I can.

---

### Pomodoro 1 - Adding end of level menu inputs.

First I need to add the controls to the controller mapping.
I need to implement the following
  * Home button (Is this level select or main menu ?)
  * Replay level
  * Next level

I have added the mappings now.

#### Moving on to: Create an input provider script.

There is some code repetition in these input provider scripts, which could be fixed by using
a simple inheritance.
