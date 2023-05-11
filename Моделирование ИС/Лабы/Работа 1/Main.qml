import QtQuick
import QtQuick.Controls
import QtQuick.Layouts
import QtCharts

ApplicationWindow {
    id: appLayout

    property int margin: 10

    height: 480
    title: qsTr("Lab1")
    visible: true
    width: 640

    ColumnLayout {
        id: mainLayout

        anchors.fill: parent
        anchors.margins: appLayout.margin

        HorizontalHeaderView {
            id: tableViewHeader
            Layout.fillWidth: true
            height: 30
            syncView: tableView
        }
        TableView {
            id: tableView
            Layout.fillWidth: true
            Layout.fillHeight: true
            model: myModel

            delegate: Rectangle {
                border.width: 1
                implicitHeight: 30
                implicitWidth: 100

                Text {
                    text: display
                }
            }
        }
    }
}
