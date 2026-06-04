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

public class EditorNotas extends JFrame implements ActionListener {

    private JTextArea areaTexto;
    private JScrollPane scroll;
    private JTextField txtBuscar;
    private JButton btnBuscar, btnContar, btnLimpiar;
    private JLabel lblResultado;

    public EditorNotas() {

        setLayout(null);
        setTitle("Editor de Notas");
        setBounds(200,100,600,450);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        areaTexto = new JTextArea();
        scroll = new JScrollPane(areaTexto);
        scroll.setBounds(20,20,540,220);
        add(scroll);

        txtBuscar = new JTextField();
        txtBuscar.setBounds(20,270,180,30);
        add(txtBuscar);

        btnBuscar = new JButton("Buscar");
        btnBuscar.setBounds(220,270,100,30);
        btnBuscar.addActionListener(this);
        add(btnBuscar);

        btnContar = new JButton("Contar");
        btnContar.setBounds(340,270,100,30);
        btnContar.addActionListener(this);
        add(btnContar);

        btnLimpiar = new JButton("Limpiar");
        btnLimpiar.setBounds(460,270,100,30);
        btnLimpiar.addActionListener(this);
        add(btnLimpiar);

        lblResultado = new JLabel("Listo...");
        lblResultado.setBounds(20,330,500,30);
        add(lblResultado);
    }

    public void actionPerformed(ActionEvent e) {

        String texto = areaTexto.getText();

        if(e.getSource() == btnContar){

            if(texto.trim().isEmpty()){
                lblResultado.setText("No hay texto.");
            }else{
                String palabras[] = texto.trim().split("\\s+");
                lblResultado.setText("Total palabras: " + palabras.length);
            }
        }

        if(e.getSource() == btnBuscar){

            String buscar = txtBuscar.getText();

            if(texto.contains(buscar)){
                lblResultado.setText("Sí existe: " + buscar);
            }else{
                lblResultado.setText("No existe: " + buscar);
            }
        }

        if(e.getSource() == btnLimpiar){

            areaTexto.setText("");
            txtBuscar.setText("");
            lblResultado.setText("Limpiado.");
        }
    }

    public static void main(String[] args) {

        EditorNotas e = new EditorNotas();
        e.setVisible(true);
    }
}