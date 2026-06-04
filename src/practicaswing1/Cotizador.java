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

public class Cotizador extends JFrame implements ActionListener {

    JRadioButton basico, profesional, empresarial;
    ButtonGroup grupo;

    JCheckBox soporte, backup, seguridad;

    JButton btn;
    JLabel total;

    public Cotizador() {

        setLayout(null);
        setTitle("Cotizador");
        setBounds(300,150,350,420);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        basico = new JRadioButton("Basico $199");
        profesional = new JRadioButton("Profesional $399");
        empresarial = new JRadioButton("Empresarial $799");

        basico.setBounds(20,20,200,25);
        profesional.setBounds(20,50,200,25);
        empresarial.setBounds(20,80,200,25);

        grupo = new ButtonGroup();
        grupo.add(basico);
        grupo.add(profesional);
        grupo.add(empresarial);

        basico.setSelected(true);

        add(basico);
        add(profesional);
        add(empresarial);

        soporte = new JCheckBox("Soporte +99");
        backup = new JCheckBox("Backup +49");
        seguridad = new JCheckBox("Seguridad +79");

        soporte.setBounds(20,140,200,25);
        backup.setBounds(20,170,200,25);
        seguridad.setBounds(20,200,200,25);

        add(soporte);
        add(backup);
        add(seguridad);

        btn = new JButton("Cotizar");
        btn.setBounds(20,260,120,35);
        btn.addActionListener(this);
        add(btn);

        total = new JLabel("Total: $0");
        total.setBounds(20,320,250,25);
        add(total);
    }

    public void actionPerformed(ActionEvent e) {

        int suma = 0;

        if(basico.isSelected()) suma += 199;
        if(profesional.isSelected()) suma += 399;
        if(empresarial.isSelected()) suma += 799;

        if(soporte.isSelected()) suma += 99;
        if(backup.isSelected()) suma += 49;
        if(seguridad.isSelected()) suma += 79;

        total.setText("Total mensual: $" + suma);
    }

    public static void main(String[] args) {

        Cotizador c = new Cotizador();
        c.setVisible(true);
    }
}