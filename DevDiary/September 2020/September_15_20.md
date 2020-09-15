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

I have completed the input provider. I am going to associate it with the end of level menu.
I have wired everything together. Now to test it!

- [x] Continue works
- [x] Replay works
- [ ] Home button not done yet (Will do soon)

#### Moving on to: Adding labels to the end of level screen

These will just be basic labels for testing purposes.

### Pomodoro 2 - Creating the end of level menu visual

This is going to be very basic, and will be refined over time.
I'm going to add in some simple transitions.
I cannot quite do the closing transition that I want because as soon as the event is invoked,
the menu gets deleted. I could maybe use a timeline to fix this, but in all honesty, I think it will be fine.

I have committed my changes.

#### Moving on to: Wiring up the 'Home' button.
