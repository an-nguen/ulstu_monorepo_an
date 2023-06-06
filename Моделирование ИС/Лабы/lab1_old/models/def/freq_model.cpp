#include "models/decl/freq_model.hpp"

FreqModel::FreqModel(QObject *parent)
        : QAbstractTableModel{parent} {

}

QVariant FreqModel::headerData(int section, Qt::Orientation orientation, int role) const {
    if (role != Qt::DisplayRole)
        return {};

    if (orientation == Qt::Horizontal)
        return QString("%1").arg(section);
    else
        return QString("%1").arg(section + 1);
}

int FreqModel::rowCount(const QModelIndex &parent) const {
    Q_UNUSED(parent)
    return static_cast<int>(this->m_freqList.count());
}

int FreqModel::columnCount(const QModelIndex &parent) const {
    Q_UNUSED(parent)
    return 1;
}

QVariant FreqModel::data(const QModelIndex &index, int role) const
{
    if (role == Qt::DisplayRole) {
        return this->m_freqList[index.row()];
    }
    return {};
}

const QList<qreal> &FreqModel::getFreqList() const {
    return m_freqList;
}

void FreqModel::setFreqList(const QList<qreal> &freqList) {
    m_freqList = freqList;
}

void FreqModel::setupAxis(int max, int intervals)
{
    const auto step = max / intervals;
    for (auto i = 0; i < intervals; i++) {
        m_categoryAxis.append(QString{"%1"}.arg(step * (i + 1)));
    }
}
