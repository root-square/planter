import tkinter
from tkinter import ttk

def load_component(window: tkinter.Tk):
    landing_frame = ttk.Frame(window)

    button = ttk.Button(window, text="Click me!")
    button.pack()
    
    return landing_frame