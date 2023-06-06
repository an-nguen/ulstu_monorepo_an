#ifndef PERF_TBL_MODEL_H
#define PERF_TBL_MODEL_H

#include <QAbstractTableModel>

#include "domains/decl/stat_perf.hpp"

class PerfTblModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    explicit PerfTblModel(QObject *parent = nullptr);

    ~PerfTblModel() override;

    void addPerf(StatPerf &perf);
    StatPerf *getPerf(qsizetype index);

    const QList<StatPerf *> &getPerfList() const;

    [[nodiscard]] int rowCount(const QModelIndex &parent = QModelIndex()) const override;
    [[nodiscard]] int columnCount(const QModelIndex &parent = QModelIndex()) const override;
    [[nodiscard]] QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const override;
    [[nodiscard]] QHash<int, QByteArray> roleNames() const override;
    [[nodiscard]] QVariant headerData(int section, Qt::Orientation orientation, int role = Qt::DisplayRole) const override;
private:
    QList<StatPerf *> m_dataList = {};
};

#endif // PERF_TBL_MODEL_H
