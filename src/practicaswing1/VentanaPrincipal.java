/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package practicaswing1;

import javax.swing.JFrame;

public class VentanaPrincipal extends JFrame {

    public VentanaPrincipal() {
        setLayout(null);
        setTitle("Mi Primera Aplicacion Swing");
        setBounds(300,150,800,600);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    public static void main(String[] args) {
        VentanaPrincipal ventana = new VentanaPrincipal();
        
        ventana.setVisible(true);
    }
}