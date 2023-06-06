import QtQuick
import QtQuick.Controls
import QtQuick.Layouts
import QtCharts
import QtQuick.Controls.Material

Window {
    id: appLayout

    height: 480
    title: qsTr("Lab1")
    visible: true
    width: 640

    ScrollView {
        id: mainScrollView
        anchors.fill: parent
        clip: true
        padding: 10
        wheelEnabled: true

        ColumnLayout {
            id: mainLayout
            anchors.fill: parent

            ColumnLayout {
                id: tableLayout
                Layout.fillWidth: true
                height: 240

//                HorizontalHeaderView {
//                    height: 30
//                    Layout.fillWidth: true
//                    syncView: tableView
//                    boundsBehavior: Flickable.StopAtBounds
//                }

                TableView {
                    id: tableView

                    columnSpacing: 1
                    rowSpacing: 1
                    Layout.fillWidth: true
                    Layout.fillHeight: true
                    Layout.alignment: Qt.AlignHCenter | Qt.AlignVCenter
                    model: myModel
                    boundsBehavior: Flickable.StopAtBounds

                    delegate: Rectangle {
                        clip: true
                        border.width: 0.5
                        implicitHeight: 30
                        implicitWidth: 120

                        Text {
                            renderType: Text.QtRendering
                            text: display
                        }
                    }
                }
            }

            Repeater {
                model: freqModelList

                ChartView {
                    Layout.fillHeight: true
                    Layout.fillWidth: true
                    antialiasing: true
                    height: 240

                    BarSeries {
                        axisX: BarCategoryAxis {
                            categories: modelData.categoryAxis
                        }

                        axisY: ValueAxis {
                            max: 0.2
                            min: 0
                            tickInterval: 0.25
                        }

                        VBarModelMapper {
                            firstBarSetColumn: 0
                            firstRow: 0
                            lastBarSetColumn: 1
                            model: modelData
                        }
                    }
                }
            }
        }
    }
}
