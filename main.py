import platform
import tkinter
import tkinter.messagebox
import sv_ttk

from interactions import landing_interaction

def main():
    # Set-up a root window
    root = tkinter.Tk()
    root.title("PLANTER")
    root.resizable(False, False)
    root.configure(background='white')

    window_width = 800
    window_height = 550

    screen_width = root.winfo_screenwidth()
    screen_height = root.winfo_screenheight()

    x_cordinate = int((screen_width/2) - (window_width/2))
    y_cordinate = int((screen_height/2) - (window_height/2))

    root.geometry("{}x{}+{}+{}".format(window_width, window_height, x_cordinate, y_cordinate))

    # Pack the initial page.
    initial_frame = landing_interaction.load_component(root)
    initial_frame.pack(expand=True)

    # This is where the magic happens
    sv_ttk.use_light_theme()

    root.mainloop()

if __name__ == "__main__":
    if platform.system() == "Windows":
        main()
    else:
        tkinter.messagebox.showerror("")