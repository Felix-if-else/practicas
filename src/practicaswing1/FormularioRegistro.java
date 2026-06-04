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
import java.awt.event.*;

public class FormularioRegistro extends JFrame implements ActionListener {

    private JLabel lblNombre, lblApellido, lblEdad;
    private JTextField txtNombre, txtApellido, txtEdad;
    private JButton btnRegistrar;

    public FormularioRegistro() {

        setLayout(null);
        setTitle("Formulario");
        setBounds(300,150,400,300);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        lblNombre = new JLabel("Nombre:");
        lblNombre.setBounds(20,30,100,25);
        add(lblNombre);

        txtNombre = new JTextField();
        txtNombre.setBounds(120,30,200,25);
        add(txtNombre);

        lblApellido = new JLabel("Apellido:");
        lblApellido.setBounds(20,70,100,25);
        add(lblApellido);

        txtApellido = new JTextField();
        txtApellido.setBounds(120,70,200,25);
        add(txtApellido);

        lblEdad = new JLabel("Edad:");
        lblEdad.setBounds(20,110,100,25);
        add(lblEdad);

        txtEdad = new JTextField();
        txtEdad.setBounds(120,110,80,25);
        add(txtEdad);

        btnRegistrar = new JButton("Registrar");
        btnRegistrar.setBounds(120,170,120,35);
        btnRegistrar.addActionListener(this);
        add(btnRegistrar);
    }

    public void actionPerformed(ActionEvent e) {

        String nombre = txtNombre.getText();
        String apellido = txtApellido.getText();
        String edad = txtEdad.getText();

        setTitle(nombre + " " + apellido + " - " + edad + " años");
    }

    public static void main(String[] args) {
        FormularioRegistro f = new FormularioRegistro();
        f.setVisible(true);
    }
}