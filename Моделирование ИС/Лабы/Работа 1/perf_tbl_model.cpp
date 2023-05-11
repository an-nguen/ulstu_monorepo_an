#include "perf_tbl_model.hpp"

PerfTblModel::PerfTblModel(QObject *parent)
    : QAbstractTableModel(parent)
{
}

void PerfTblModel::addPerf(StatPerf perf) {
    this->m_dataList.append(perf);
}

int PerfTblModel::rowCount(const QModelIndex &parent) const {
    Q_UNUSED(parent)
    return static_cast<int>(this->m_dataList.count());
}

int PerfTblModel::columnCount(const QModelIndex &parent) const {
    Q_UNUSED(parent)
    return 4;
}

QVariant PerfTblModel::data(const QModelIndex &index, int role) const {
    auto perf = this->m_dataList.at(index.row());

    if (role == Qt::DisplayRole)
        switch (index.column()) {
            case 0:
                return QString{"%1"}.arg(perf.getCount());
            case 1:
                return QString{"%1"}.arg(perf.getExpectedValue(), 0, 'g', 2);
            case 2:
                return QString{"%1"}.arg(perf.getVariance(), 0, 'g', 2);
            case 3:
                return QString{"%1"}.arg(perf.getStandardDeviation(), 0, 'g', 2);
            default:
                return {};
        }

    return {};
}

QHash<int, QByteArray> PerfTblModel::roleNames() const {
    return { {Qt::DisplayRole, "display"} };
}

QVariant PerfTblModel::headerData(int section, Qt::Orientation orientation, int role) const {
    switch(section) {
        case 0:
            return QString{"N"};
        case 1:
            return QString{"Expected value"};
        case 2:
            return QString{"Variance"};
        case 3:
            return QString{"Standard Deviation"};
        default:
            return QAbstractItemModel::headerData(section, orientation, role);
    }
}
