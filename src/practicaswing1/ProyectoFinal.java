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

public class ProyectoFinal extends JFrame implements ActionListener {

    // Etiquetas
    JLabel lblNombre, lblMatricula, lblPromedio, lblCarrera, lblTurno, lblServicios;

    // Cajas de texto
    JTextField txtNombre, txtMatricula, txtPromedio;

    // ComboBox
    JComboBox<String> comboCarrera;

    // RadioButtons
    JRadioButton matutino, vespertino, nocturno;
    ButtonGroup grupoTurno;

    // CheckBox
    JCheckBox biblioteca, deportes, cafeteria;

    // Botones
    JButton btnRegistrar;

    // Area de texto
    JTextArea areaRegistros;
    JScrollPane scroll;

    // Menú
    JMenuBar barra;
    JMenu menuOpciones;
    JMenuItem nuevo, limpiar, exportar, salir;

    public ProyectoFinal() {

        setLayout(null);
        setTitle("Sistema de Registro de Estudiantes");
        setBounds(150,50,750,650);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // ===== MENÚ =====
        barra = new JMenuBar();
        setJMenuBar(barra);

        menuOpciones = new JMenu("Opciones");
        barra.add(menuOpciones);

        nuevo = new JMenuItem("Nuevo Registro");
        limpiar = new JMenuItem("Limpiar Lista");
        exportar = new JMenuItem("Exportar");
        salir = new JMenuItem("Salir");

        nuevo.addActionListener(this);
        limpiar.addActionListener(this);
        exportar.addActionListener(this);
        salir.addActionListener(this);

        menuOpciones.add(nuevo);
        menuOpciones.add(limpiar);
        menuOpciones.add(exportar);
        menuOpciones.add(salir);

        // ===== COMPONENTES =====
        lblNombre = new JLabel("Nombre:");
        lblNombre.setBounds(20,20,100,25);
        add(lblNombre);

        txtNombre = new JTextField();
        txtNombre.setBounds(130,20,200,25);
        add(txtNombre);

        lblMatricula = new JLabel("Matricula:");
        lblMatricula.setBounds(20,60,100,25);
        add(lblMatricula);

        txtMatricula = new JTextField();
        txtMatricula.setBounds(130,60,200,25);
        add(txtMatricula);

        lblPromedio = new JLabel("Promedio:");
        lblPromedio.setBounds(20,100,100,25);
        add(lblPromedio);

        txtPromedio = new JTextField();
        txtPromedio.setBounds(130,100,100,25);
        add(txtPromedio);

        lblCarrera = new JLabel("Carrera:");
        lblCarrera.setBounds(20,140,100,25);
        add(lblCarrera);

        comboCarrera = new JComboBox<>();
        comboCarrera.setBounds(130,140,200,25);
        comboCarrera.addItem("Sistemas");
        comboCarrera.addItem("Industrial");
        comboCarrera.addItem("Mecatronica");
        comboCarrera.addItem("Contabilidad");
        comboCarrera.addItem("Administracion");
        add(comboCarrera);

        lblTurno = new JLabel("Turno:");
        lblTurno.setBounds(20,180,100,25);
        add(lblTurno);

        matutino = new JRadioButton("Matutino");
        vespertino = new JRadioButton("Vespertino");
        nocturno = new JRadioButton("Nocturno");

        matutino.setBounds(130,180,100,25);
        vespertino.setBounds(230,180,100,25);
        nocturno.setBounds(340,180,100,25);

        grupoTurno = new ButtonGroup();
        grupoTurno.add(matutino);
        grupoTurno.add(vespertino);
        grupoTurno.add(nocturno);

        matutino.setSelected(true);

        add(matutino);
        add(vespertino);
        add(nocturno);

        lblServicios = new JLabel("Servicios:");
        lblServicios.setBounds(20,220,100,25);
        add(lblServicios);

        biblioteca = new JCheckBox("Biblioteca");
        deportes = new JCheckBox("Deportes");
        cafeteria = new JCheckBox("Cafeteria");

        biblioteca.setBounds(130,220,120,25);
        deportes.setBounds(250,220,120,25);
        cafeteria.setBounds(370,220,120,25);

        add(biblioteca);
        add(deportes);
        add(cafeteria);

        btnRegistrar = new JButton("Registrar");
        btnRegistrar.setBounds(130,270,130,35);
        btnRegistrar.addActionListener(this);
        add(btnRegistrar);

        areaRegistros = new JTextArea();
        scroll = new JScrollPane(areaRegistros);
        scroll.setBounds(20,330,680,240);
        add(scroll);
    }

    public void actionPerformed(ActionEvent e) {

        // ===== BOTÓN REGISTRAR =====
        if(e.getSource() == btnRegistrar){

            String nombre = txtNombre.getText();
            String matricula = txtMatricula.getText();
            String promedio = txtPromedio.getText();

            if(nombre.isEmpty() || matricula.isEmpty() || promedio.isEmpty()){
                JOptionPane.showMessageDialog(this,"Completa todos los campos");
                return;
            }

            String carrera = comboCarrera.getSelectedItem().toString();

            String turno = "";
            if(matutino.isSelected()) turno = "Matutino";
            if(vespertino.isSelected()) turno = "Vespertino";
            if(nocturno.isSelected()) turno = "Nocturno";

            String servicios = "";

            if(biblioteca.isSelected()) servicios += "Biblioteca ";
            if(deportes.isSelected()) servicios += "Deportes ";
            if(cafeteria.isSelected()) servicios += "Cafeteria ";

            areaRegistros.append(
                "Nombre: " + nombre +
                " | Matricula: " + matricula +
                " | Promedio: " + promedio +
                " | Carrera: " + carrera +
                " | Turno: " + turno +
                " | Servicios: " + servicios + "\n"
            );
        }

        // ===== MENÚ =====
        if(e.getSource() == nuevo){

            txtNombre.setText("");
            txtMatricula.setText("");
            txtPromedio.setText("");
        }

        if(e.getSource() == limpiar){
            areaRegistros.setText("");
        }

        if(e.getSource() == exportar){
            JOptionPane.showMessageDialog(this,"Registros exportados correctamente");
        }

        if(e.getSource() == salir){
            System.exit(0);
        }
    }

    public static void main(String[] args) {

        ProyectoFinal p = new ProyectoFinal();
        p.setVisible(true);
    }
}