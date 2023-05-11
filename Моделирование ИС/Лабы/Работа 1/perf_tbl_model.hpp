#ifndef PERF_TBL_MODEL_H
#define PERF_TBL_MODEL_H

#include <QAbstractTableModel>

#include "stat_perf.hpp"

class PerfTblModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    explicit PerfTblModel(QObject *parent = nullptr);

    void addPerf(StatPerf perf);

    int rowCount(const QModelIndex &parent = QModelIndex()) const override;
    int columnCount(const QModelIndex &parent = QModelIndex()) const override;
    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const override;
    QHash<int, QByteArray> roleNames() const override;
    QVariant headerData(int section, Qt::Orientation orientation, int role = Qt::DisplayRole) const override;
private:
    QList<StatPerf> m_dataList;
};

#endif // PERF_TBL_MODEL_H
