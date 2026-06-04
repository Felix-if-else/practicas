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

public class Calculadora extends JFrame implements ActionListener {

    private JLabel lbl1, lbl2, lblResultado;
    private JTextField txt1, txt2;
    private JComboBox combo;
    private JButton btnCalcular;

    public Calculadora() {

        setLayout(null);
        setTitle("Calculadora");
        setBounds(300,150,400,300);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        lbl1 = new JLabel("Numero 1:");
        lbl1.setBounds(20,30,100,25);
        add(lbl1);

        txt1 = new JTextField();
        txt1.setBounds(120,30,150,25);
        add(txt1);

        lbl2 = new JLabel("Numero 2:");
        lbl2.setBounds(20,70,100,25);
        add(lbl2);

        txt2 = new JTextField();
        txt2.setBounds(120,70,150,25);
        add(txt2);

        combo = new JComboBox();
        combo.setBounds(120,110,150,25);
        combo.addItem("Suma");
        combo.addItem("Resta");
        combo.addItem("Multiplicacion");
        combo.addItem("Division");
        add(combo);

        btnCalcular = new JButton("Calcular");
        btnCalcular.setBounds(120,150,120,35);
        btnCalcular.addActionListener(this);
        add(btnCalcular);

        lblResultado = new JLabel("Resultado:");
        lblResultado.setBounds(20,210,300,25);
        add(lblResultado);
    }

    public void actionPerformed(ActionEvent e) {

        double n1 = Double.parseDouble(txt1.getText());
        double n2 = Double.parseDouble(txt2.getText());
        double res = 0;

        int op = combo.getSelectedIndex();

        if(op == 0)
            res = n1 + n2;

        if(op == 1)
            res = n1 - n2;

        if(op == 2)
            res = n1 * n2;

        if(op == 3)
            res = n1 / n2;

        lblResultado.setText("Resultado: " + res);
    }

    public static void main(String[] args) {

        Calculadora c = new Calculadora();
        c.setVisible(true);
    }
}