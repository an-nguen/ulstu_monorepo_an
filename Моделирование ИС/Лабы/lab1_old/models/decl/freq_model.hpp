#ifndef FREQMODEL_H
#define FREQMODEL_H

#include <QAbstractTableModel>
#include <QBarCategoryAxis>

class FreqModel : public QAbstractTableModel
{
    Q_OBJECT
    Q_PROPERTY(QStringList categoryAxis MEMBER m_categoryAxis NOTIFY categoryAxisChanged)
public:
    explicit FreqModel(QObject *parent = nullptr);

    // QAbstractItemModel interface
    [[nodiscard]] int rowCount(const QModelIndex &parent) const override;

    [[nodiscard]] int columnCount(const QModelIndex &parent) const override;

    [[nodiscard]] QVariant data(const QModelIndex &index, int role) const override;

    [[nodiscard]] QVariant headerData(int section, Qt::Orientation orientation, int role) const override;

    const QList<qreal> &getFreqList() const;

    void setFreqList(const QList<qreal> &freqList);

    void setupAxis(int max, int intervals);

signals:
    void categoryAxisChanged();

private:
    QList<qreal> m_freqList{};
    QStringList m_categoryAxis = {};
};

#endif // FREQMODEL_H
