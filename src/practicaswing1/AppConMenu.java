/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package practicaswing1;

/**
 *
 * @author HP
 */
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class AppConMenu extends JFrame implements ActionListener {

    JMenuBar barra;
    JMenu menuVista, menuVentana, menuAyuda;
    JMenuItem rojo, azul, grande, normal, salir, acerca;

    public AppConMenu() {

        setLayout(null);
        setTitle("Aplicacion con Menu");
        setBounds(250,150,600,400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        barra = new JMenuBar();
        setJMenuBar(barra);

        menuVista = new JMenu("Vista");
        barra.add(menuVista);

        rojo = new JMenuItem("Fondo Rojo");
        azul = new JMenuItem("Fondo Azul");

        rojo.addActionListener(this);
        azul.addActionListener(this);

        menuVista.add(rojo);
        menuVista.add(azul);

        menuVentana = new JMenu("Ventana");
        barra.add(menuVentana);

        normal = new JMenuItem("800 x 600");
        grande = new JMenuItem("1024 x 768");

        normal.addActionListener(this);
        grande.addActionListener(this);

        menuVentana.add(normal);
        menuVentana.add(grande);

        menuAyuda = new JMenu("Ayuda");
        barra.add(menuAyuda);

        acerca = new JMenuItem("Acerca de");
        salir = new JMenuItem("Salir");

        acerca.addActionListener(this);
        salir.addActionListener(this);

        menuAyuda.add(acerca);
        menuAyuda.add(salir);
    }

    public void actionPerformed(ActionEvent e) {

        if(e.getSource() == rojo)
            getContentPane().setBackground(Color.red);

        if(e.getSource() == azul)
            getContentPane().setBackground(Color.blue);

        if(e.getSource() == normal)
            setSize(800,600);

        if(e.getSource() == grande)
            setSize(1024,768);

        if(e.getSource() == acerca)
            JOptionPane.showMessageDialog(this,"Programa hecho en Swing");

        if(e.getSource() == salir)
            System.exit(0);
    }

    public static void main(String[] args) {

        AppConMenu a = new AppConMenu();
        a.setVisible(true);
    }
}